using System.Runtime.InteropServices;
using Query_Builder_test.Models;

// Order of deletions based on their dependencies.
List<string> Entities = new List<string>()
                        {
                          "MemberTeeTimes",
                          "StandingTeeTimes",
                          "Members",
                          "RestrictedTimes",
                          "Memberships",
                          "TeeTimes",
                          "Events"
                        };

Query resetDBQuery = new Query(Entities);

// Works perfectly if the entities are already exist.
// This will give you errors if an entity does not exist.
string deleteAllQueryString = resetDBQuery.GetDeleteAllQueryString();
string resetSeedQueryString = resetDBQuery.GetResetQueryString();

try
{
  Queries queries = new Queries();

  queries.ExecuteQuery(deleteAllQueryString);
  queries.ExecuteQuery(resetSeedQueryString);

  Console.WriteLine("Successfully reset the DB!");
}
catch (System.Exception ex)
{
  Console.WriteLine(ex.Message.ToString());
}

// Reversed the entity list to prevent errors from inserting non-dependent entity first.
Entities.Reverse();

try
{
  LoadData(Entities);
  Console.WriteLine("Successfully loaded the data!");
}
catch (System.Exception ex)
{
  Console.WriteLine(ex.Message.ToString());
}


void LoadData(List<string> Entities)
{
  Queries queries = new Queries();

  string folderName = GetFolderNameByOS();

  foreach (string entity in Entities)
  {
    // Only accepts txt files for now.
    string fileName = $"{folderName}{entity}.txt";

    Query query = new Query(fileName, entity);

    if (!String.IsNullOrEmpty(query.GetInsertQueryString()))
      queries.ExecuteQuery(query.GetInsertQueryString());
    else
      Console.WriteLine();
  }
}

string GetFolderNameByOS()
{
  string folderName;

  if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
    folderName = @"Data\";
  else
    folderName = @"Data/";

  return folderName;
}