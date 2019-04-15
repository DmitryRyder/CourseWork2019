using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Core.Contexts
{
    public class AccountingForEnergyContext : DbContext
    {
        public AccountingForEnergyContext(DbContextOptions<AccountingForEnergyContext> options) : base(options) { }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Type_of_room> Type_of_rooms { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ElectricsByOrganization>().HasKey(c => new { c.ElectricId, c.OrganizationId });
            //modelBuilder.Entity<Room_rental>().HasKey(c => new { c.RoomId, c.OrganizationId });

            modelBuilder.Entity<Room>()
                .HasOne(p => p.Building)
                .WithMany(t => t.rooms)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Room>()
                .HasOne(p => p.TypeOfRoom)
                .WithMany(t => t.rooms)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Room_rental>()
            //    .HasKey(t => new { t.RoomId, t.OrganizationId });

            //modelBuilder.Entity<Room_rental>()
            //    .HasOne(sc => sc.Room)
            //    .WithMany(s => s.Room_rentals)
            //    .HasForeignKey(sc => sc.RoomId);

            //modelBuilder.Entity<Room_rental>()
            //    .HasOne(sc => sc.Organization)
            //    .WithMany(c => c.Room_rentals)
            //    .HasForeignKey(sc => sc.OrganizationId);

            //modelBuilder.Entity<ElectricsByOrganization>()
            //    .HasKey(t => new { t.OrganizationId, t.ElectricId });

            //modelBuilder.Entity<ElectricsByOrganization>()
            //    .HasOne(sc => sc.Organization)
            //    .WithMany(s => s.ElectricsByOrganization)
            //    .HasForeignKey(sc => sc.OrganizationId);

            //modelBuilder.Entity<ElectricsByOrganization>()
            //    .HasOne(sc => sc.Electric)
            //    .WithMany(c => c.ElectricsByOrganization)
            //    .HasForeignKey(sc => sc.ElectricId);
        }
    }
}
