using System.Data.SqlClient;

namespace Query_Builder_test.Models
{
  public class Queries
  {
    private const string CONNECTION_STRING = "Server=localhost,1433;Database=ClubBAISTDB;User Id=sa;Password=EMirandaPassword!";

    private SqlConnection _sqlConnection;

    public Queries()
    {
      _sqlConnection = new SqlConnection(CONNECTION_STRING);
    }

    public void ExecuteQuery(string queryString)
    {
      _sqlConnection.Open();

      SqlCommand sqlCommand = new SqlCommand(queryString, _sqlConnection);
      sqlCommand.ExecuteNonQuery();

      _sqlConnection.Close();
    }
  }
}