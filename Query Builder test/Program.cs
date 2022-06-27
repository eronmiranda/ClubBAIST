using System.Reflection;
using System.Text;
using static System.Console;
using Query_Builder_test.Models;

Query query = new Query(@"Data/Memberships.txt", "Memberships");

WriteLine(query.GetQueryString());