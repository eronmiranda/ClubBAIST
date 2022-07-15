import { StringifyOptions } from "querystring";

export interface Member
{
  MemberNumber: bigint,
  FirstName: string,
  LastName: string,
  Address: string,
  PostalCode: string,
  PhoneNumber: string,
  AltPhoneNumber?: string,
  Email: string,
  DateOfBirth: Date,
  Occupation: string,
  CompanyName: string,
  CompanyAddress: string,
  CompanyPostalCode: string,
  CompanyPhoneNumber:string,
  MembershipID: bigint
}