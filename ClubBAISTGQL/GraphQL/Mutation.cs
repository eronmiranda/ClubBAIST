using ClubBAISTGQL.Data;
using ClubBAISTGQL.GraphQL.Memberships;
using ClubBAISTGQL.Models;

namespace ClubBAISTGQL.GraphQL
{
  public class Mutation
  {
    [UseDbContext(typeof(AppDbContext))]
    public async Task<AddMembershipPayload> AddMembershipAsync(AddMembershipInput input, [ScopedService] AppDbContext context)
    {
      var membership = new Membership
      {
        Description = input.Description
      };

      context.Memberships.Add(membership);
      await context.SaveChangesAsync();

      return new AddMembershipPayload(membership);
    }
  }
}