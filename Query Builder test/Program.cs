using static System.Console;
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
string resetQuery = resetDBQuery.GetResetQueryString();
string deleteAllQuery = resetDBQuery.GetDeleteAllQueryString();

Query insertQuery = new Query(@"Data/Memberships.txt", "Memberships");
Queries queries = new Queries(insertQuery.GetInsertQueryString());
queries.ResetDB(deleteAllQuery, resetQuery);
queries.ExecuteQuery();