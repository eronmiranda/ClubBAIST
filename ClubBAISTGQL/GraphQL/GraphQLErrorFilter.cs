namespace ClubBAISTGQL.GraphQL
{
  // Use for reading error messages on JSON data form.
  public class GraphQLErrorFilter : IErrorFilter
  {
    public IError OnError(IError error)
    {
      return error.WithMessage(error.Exception.Message);
    }
  }
}