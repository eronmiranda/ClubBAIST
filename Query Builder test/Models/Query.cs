using System.Reflection;
using System.Text;

namespace Query_Builder_test.Models
{
  public class Query
  {
    private string _columns;
    private string _values;
    private string _pathName;

    public string EntityName { get; set; }

    public string FileName { get; set; }

    public List<string> Entities { get; set; }

    public Query(string FileName, string EntityName)
    {
      this.EntityName = EntityName;
      this.FileName = FileName;
      _pathName = GetPath();
      _columns = GetColumns();
      _values = GetValues();
    }

    public Query(List<string> Entities)
    {
      this.Entities = Entities;
    }


    // Gets the combined directory name and the file name provided.
    private string GetPath()
    {
      string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      // Removes if its in the development
      if (directoryName.Contains(@"/bin/Debug/net6.0"))
      {
        directoryName = directoryName.Remove((directoryName.Length - (@"/bin/Debug/net6.0").Length));
      }
      else if (directoryName.Contains(@"\bin\Debug\net6.0"))
      {

        directoryName = directoryName.Remove((directoryName.Length - (@"\bin\Debug\net6.0").Length));
      }

      return Path.Combine(directoryName, FileName);
    }

    // Only reads the first line of the formatted text file.
    private string GetColumns()
    {
      string columns;
      try
      {
        columns = File.ReadLines(_pathName).First().Trim();
      }
      catch
      {
        columns = String.Empty;
      }
      return columns;
    }

    private string GetValues()
    {
      StringBuilder stringBuilder = new StringBuilder();
      List<string> dataList = File.ReadLines(_pathName)?.ToList();

      if (dataList.Count > 0)
      {
        dataList.RemoveAt(0);
        foreach (string line in dataList)
        {
          // /n is added for readability when printed.
          stringBuilder.Append($"({line}),\n");
        }
        // Removes /n and extra comma at the end.
        stringBuilder.Length -= 2;
      }

      return stringBuilder.ToString();
    }

    public string GetInsertQueryString()
    {
      string insertQueryString = String.Empty;
      if (!String.IsNullOrEmpty(_columns) && !String.IsNullOrEmpty(_values))
        insertQueryString = $"INSERT INTO {EntityName} ({_columns}) VALUES \n{_values};";

      return insertQueryString;
    }

    public string GetResetQueryString()
    {
      StringBuilder resetSeedQuery = new StringBuilder();
      foreach (string entity in Entities)
      {
        if (entity != "MemberTeeTimes")
        {
          resetSeedQuery.Append($"DBCC CHECKIDENT('{entity}', RESEED, 0);\n");
        }
      }

      return resetSeedQuery.ToString();
    }

    public string GetDeleteAllQueryString()
    {
      StringBuilder deleteQuery = new StringBuilder();

      foreach (string entity in Entities)
      {
        deleteQuery.Append($"DELETE FROM {entity};\n");
      }

      return deleteQuery.ToString();
    }
  }
}