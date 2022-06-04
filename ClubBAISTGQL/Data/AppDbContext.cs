using Microsoft.EntityFrameworkCore;

namespace ClubBAISTGQL.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
  }
}