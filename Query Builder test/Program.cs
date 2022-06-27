using System.Text;
using static System.Console;

const string MEMBERSHIP_FILE = @"C:\Users\Eron\Documents\Git\BAIST-Capstone-Project\ClubBAIST-GQL\Query Builder test\Memberships.txt";

string entityName, columns;
entityName = "Memberships";
columns = "[Description]";

StringBuilder stringBuilder = new StringBuilder();

foreach (string line in File.ReadLines(MEMBERSHIP_FILE))
{
  stringBuilder.Append($"({line}),\n");
}
stringBuilder.Length -= 2;

WriteLine($"INSERT INTO {entityName} ({columns}) VALUES \n{stringBuilder.ToString()};");