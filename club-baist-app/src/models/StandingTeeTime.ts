export interface StandingTeeTime{
  StandingTeeTimeID: bigint,
  StartDate: Date,
  EndDate: Date,
  RequestedTeeTime: string, //timespan
  DayOfWeek: string
}