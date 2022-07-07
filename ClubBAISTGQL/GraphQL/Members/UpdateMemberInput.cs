namespace ClubBAISTGQL.GraphQL.Members
{
  public record UpdateMemberInput(long MemberNumber,
                                  string FirstName,
                                  string LastName,
                                  string Address,
                                  string PostalCode,
                                  string PhoneNumber,
                                  string AltPhoneNumber,
                                  string Email,
                                  string DateOfBirth,
                                  string Occupation,
                                  string CompanyName,
                                  string CompanyAddress,
                                  string CompanyPostalCode,
                                  string CompanyPhoneNumber,
                                  long MembershipID);
}