namespace ClubBAISTGQL.GraphQL.StandingTeeTimes
{
  public record AddStandingTeeTimeInput(string StartDate,
                                        string EndDate,
                                        int DayOfWeek);
}