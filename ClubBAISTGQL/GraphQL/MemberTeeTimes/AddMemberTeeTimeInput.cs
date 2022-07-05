namespace ClubBAISTGQL.GraphQL.MemberTeeTimes
{
  public record AddMemberTeeTimeInput(long TeeTimeID,
                                      long MemberNumber,
                                      long? StandingTeeTimeID);
}