using Query_Builder_test.Models;

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

Query insertQuery = new Query(@"Data/Memberships.txt", "Memberships");
string insertQueryString = insertQuery.GetInsertQueryString();

Queries queries = new Queries();

queries.ExecuteQuery(deleteAllQueryString);
queries.ExecuteQuery(resetSeedQueryString);

queries.ExecuteQuery(insertQueryString);