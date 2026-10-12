using Clup.Models;
using Microsoft.EntityFrameworkCore;

namespace Clup.AppDbContext
{
    public class ClupDbContext : DbContext
    {
        public ClupDbContext(DbContextOptions<ClupDbContext> options) : base(options)
        {
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Member>()
                .HasOne(m => m.Membership)
                .WithOne(mb => mb.Member)
                .HasForeignKey<Membership>(mb => mb.MemberId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Member)
                .WithMany(m => m.Bookings)
                .HasForeignKey(b => b.MemberId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Facility)
                .WithMany(f => f.Bookings)
                .HasForeignKey(b => b.FacilityId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Membership)
                .WithMany(mb => mb.Payments)
                .HasForeignKey(p => p.MembershipId);



            //Configure EF Core data seeding in OnModelCreating using HasData(). Add the following sample records. Keep foreign-key values consistent with the relationships.
            //1. Members — 3 Records
          

                
            modelBuilder.Entity<Payment>()
                .HasData(
                    new Payment { Id = 1, MembershipId = 1, Amount = 500, PaymentDate = DateTime.Now },
                    new Payment { Id = 2, MembershipId = 2, Amount = 1000, PaymentDate = DateTime.Now },
                    new Payment { Id = 3, MembershipId = 3, Amount = 1500, PaymentDate = DateTime.Now }
                );

           




        }

    }
}
