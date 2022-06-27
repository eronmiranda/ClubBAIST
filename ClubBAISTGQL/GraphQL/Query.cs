using System.Linq;
using ClubBAISTGQL.Data;
using ClubBAISTGQL.Models;
using HotChocolate;
using HotChocolate.Data;

namespace ClubBAISTGQL.GraphQL
{
    [GraphQLDescription("Represents the queries available.")]
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Membership> GetMembership([ScopedService] AppDbContext context)
        {
            return context.Memberships;
        }
    }
}