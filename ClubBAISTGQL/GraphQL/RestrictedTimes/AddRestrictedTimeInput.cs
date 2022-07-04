namespace ClubBAISTGQL.GraphQL.RestrictedTimes
{
  public record AddRestrictedTimeInput(string RestrictedDay,
                                       string RestrictedTimeStart,
                                       string RestrictedTimeEnd,
                                       long MembershipID);
}