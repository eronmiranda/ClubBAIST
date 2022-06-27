using System.Data.SqlClient;

namespace Query_Builder_test.Models
{
  public class Queries
  {
    private const string CONNECTION_STRING = "Server=localhost,1433;Database=ClubBAISTDB;User Id=sa;Password=EMirandaPassword!";
    private string _queryString;

    public Queries(string queryString)
    {
      this._queryString = queryString;
    }

    public void ExecuteQuery()
    {
      SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
      sqlConnection.Open();
      SqlCommand sqlCommand = new SqlCommand(_queryString, sqlConnection);
      sqlCommand.ExecuteNonQuery();
      sqlConnection.Close();
    }
  }
}