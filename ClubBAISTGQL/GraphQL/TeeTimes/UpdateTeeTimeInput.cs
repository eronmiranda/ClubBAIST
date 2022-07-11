namespace ClubBAISTGQL.GraphQL.TeeTimes
{
  public record UpdateTeeTimeInput(long TeeTimeID,
                                   string DateTeeTime,
                                   int? CartsRequested,
                                   long? EventID);
}