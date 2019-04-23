using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Core.Contexts
{
    public class RentalRoomsContext : DbContext
    {
        public RentalRoomsContext(DbContextOptions<RentalRoomsContext> options) : base(options) { }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .HasOne(p => p.Building)
                .WithMany(t => t.rooms)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Room_rental>()
                .HasOne(p => p.Room)
                .WithMany(t => t.Room_rentals)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Room_rental>()
                .HasOne(p => p.Organization)
                .WithMany(t => t.Room_rentals)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Room_rental>()
                .HasKey(t => new { t.Id });

            modelBuilder.Entity<Invoice>()
                .HasOne(p => p.Room_Rental)
                .WithMany(t => t.Invoices)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
