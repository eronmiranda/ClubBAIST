using System.Linq;
using ClubBAISTGQL.Data;
using ClubBAISTGQL.Models;
using HotChocolate;
using HotChocolate.Data;

namespace ClubBAISTGQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Membership> GetMembership([Service] AppDbContext context)
        {
            return context.Memberships;
        }
    }
}