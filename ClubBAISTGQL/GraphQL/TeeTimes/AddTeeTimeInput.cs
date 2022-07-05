namespace ClubBAISTGQL.GraphQL.TeeTimes
{
  public record AddTeeTimeInput(string DateTeeTime,
                                int? CartsRequested,
                                long? EventID);
}