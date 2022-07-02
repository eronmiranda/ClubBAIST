using Microsoft.EntityFrameworkCore;
using ClubBAISTGQL.Models;

namespace ClubBAISTGQL.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Event> Events { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Membership> Memberships { get; set; }
    public DbSet<MemberTeeTime> MemberTeeTimes { get; set; }
    public DbSet<StandingTeeTime> StandingTeeTimes { get; set; }
    public DbSet<TeeTime> TeeTimes { get; set; }
    public DbSet<RestrictedTime> RestrictedTimes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Creates a concatenated key on the MemberTeeTime entity.
      modelBuilder
        .Entity<MemberTeeTime>()
        .HasKey(p => new { p.MemberNumber, p.TeeTimeID });

      // TeeTime to MemberTeeTime.
      modelBuilder
        .Entity<TeeTime>()
        .HasMany(p => p.MemberTeeTimes)
        .WithOne(p => p.TeeTime!)
        .HasForeignKey(p => p.TeeTimeID);

      // Member to MemberTeeTime.
      modelBuilder
        .Entity<Member>()
        .HasMany(p => p.MemberTeeTimes)
        .WithOne(p => p.Member!)
        .HasForeignKey(p => p.MemberNumber);

      // StandingTeeTime to MemberTeeTime.
      modelBuilder
        .Entity<StandingTeeTime>()
        .HasMany(p => p.MemberTeeTimes)
        .WithOne(p => p.StandingTeeTime!)
        .HasForeignKey(p => p.StandingTeeTimeID);

      // TeeTime to Event.
      modelBuilder
        .Entity<TeeTime>()
        .HasOne(p => p.Event)
        .WithMany(p => p.TeeTimes)
        .HasForeignKey(p => p.EventID);

      // Event to TeeTime.
      modelBuilder
        .Entity<Event>()
        .HasMany(p => p.TeeTimes)
        .WithOne(p => p.Event!)
        .HasForeignKey(p => p.EventID);

      // Member to Membership.
      modelBuilder
        .Entity<Member>()
        .HasOne(p => p.Membership)
        .WithMany(p => p.Members)
        .HasForeignKey(p => p.MembershipID);

      // Membership to Member.
      modelBuilder
        .Entity<Membership>()
        .HasMany(p => p.Members)
        .WithOne(p => p.Membership!)
        .HasForeignKey(p => p.MembershipID);

      // Membership to RestrictedTime
      modelBuilder
        .Entity<Membership>()
        .HasMany(p => p.RestrictedTimes)
        .WithOne(p => p.Membership!)
        .HasForeignKey(p => p.MembershipID);

      // RestrictedTime to Membership
      modelBuilder
        .Entity<RestrictedTime>()
        .HasOne(p => p.Membership)
        .WithMany(p => p.RestrictedTimes)
        .HasForeignKey(p => p.MembershipID);

      base.OnModelCreating(modelBuilder);
    }
  }
}