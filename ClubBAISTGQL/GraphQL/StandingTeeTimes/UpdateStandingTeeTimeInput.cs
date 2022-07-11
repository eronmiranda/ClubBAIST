namespace ClubBAISTGQL.GraphQL.StandingTeeTimes
{
  public record UpdateStandingTeeTimeInput(long StandingTeeTimeID,
                                           string StartDate,
                                           string EndDate,
                                           int DayOfWeek,
                                           string RequestedTeeTime);
}