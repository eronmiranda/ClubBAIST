namespace ClubBAISTGQL.GraphQL.RestrictedTimes
{
  public record UpdateRestrictedTimeInput(long RestrictedTimeID,
                                          string RestrictedDay,
                                          string RestrictedTimeStart,
                                          string RestrictedTimeEnd,
                                          long MembershipID);
}