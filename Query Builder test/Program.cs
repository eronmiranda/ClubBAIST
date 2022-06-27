using System.Reflection;
using System.Text;
using static System.Console;

string pathName = GetPath(@"Data/Memberships.txt");
string entityName = "Memberships";
string columns = GetColumns(pathName);
string values = GetValues(pathName);

PrintQuery(entityName, columns, values);

// Gets the combined directory name and the file name provided.
string GetPath(string fileName)
{
  string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
  // Removes if its in the development
  if (directoryName.Contains(@"/bin/Debug/net6.0"))
  {
    directoryName = directoryName.Remove((directoryName.Length - (@"/bin/Debug/net6.0").Length));
  }
  return Path.Combine(directoryName, fileName);
}

string GetColumns(string fileName)
{
  return File.ReadLines(pathName).First();
}

string GetValues(string pathName)
{
  StringBuilder stringBuilder = new StringBuilder();

  List<string> dataList = File.ReadLines(pathName).ToList();
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

void PrintQuery(string entityName, string columns, string values)
{
  WriteLine($"INSERT INTO {entityName} ({columns}) VALUES \n{values};");
}