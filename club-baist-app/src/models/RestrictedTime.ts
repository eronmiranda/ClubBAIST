export interface RestrictedTeeTime
{
  RestrictedTimeID: bigint,
  RestrictedDate: string,
  RestrictedTimeStart: string, // TimeSpan
  RestrictedTimeEnd: string, // TimeSpan
  MembershipID: bigint
}