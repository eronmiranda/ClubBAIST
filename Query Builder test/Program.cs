﻿using Query_Builder_test.Models;

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

  foreach (string entity in Entities)
  {
    string fileName = $@"Data\{entity}.txt";

    Query query = new Query(fileName, entity);

    if (!String.IsNullOrEmpty(query.GetInsertQueryString()))
      queries.ExecuteQuery(query.GetInsertQueryString());
  }
}
