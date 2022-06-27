using static System.Console;
using Query_Builder_test.Models;

Query query = new Query(@"Data/Memberships.txt", "Memberships");

WriteLine(query.GetQueryString());

Queries queries = new Queries(query.GetQueryString());
queries.ExecuteQuery();