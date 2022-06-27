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

    public Query(string FileName, string EntityName)
    {
      this.EntityName = EntityName;
      this.FileName = FileName;
      _pathName = GetPath();
      _columns = GetColumns();
      _values = GetValues();
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
      return Path.Combine(directoryName, FileName);
    }

    // Only reads the first line of the formatted text file.
    private string GetColumns()
    {
      return File.ReadLines(_pathName).First();
    }

    private string GetValues()
    {
      StringBuilder stringBuilder = new StringBuilder();

      List<string> dataList = File.ReadLines(_pathName).ToList();
      dataList.RemoveAt(0);
      foreach (string line in dataList)
      {
        // /n is added for readability when printed.
        stringBuilder.Append($"({line}),\n");
      }
      // Removes /n and extra comma at the end.
      stringBuilder.Length -= 2;

      return stringBuilder.ToString();
    }

    public string GetQueryString()
    {
      return $"INSERT INTO {EntityName} ({_columns}) VALUES \n{_values};";
    }

  }
}