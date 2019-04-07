using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Core.Contexts
{
    public class AccountingForEnergyContext : DbContext
    {
        public AccountingForEnergyContext(DbContextOptions<AccountingForEnergyContext> options) : base(options) { }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Type_of_room> Type_of_rooms { get; set; }
        public DbSet<Building> Buildings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rooms_by_building>()
                .HasKey(t => new { t.Buildings_Id, t.Rooms_Id });

            modelBuilder.Entity<Rooms_by_building>()
                .HasOne(sc => sc.Building)
                .WithMany(s => s.RoomsByBuilding)
                .HasForeignKey(sc => sc.Buildings_Id);

            modelBuilder.Entity<Rooms_by_building>()
                .HasOne(sc => sc.Room)
                .WithMany(c => c.RoomsByBuilding)
                .HasForeignKey(sc => sc.Rooms_Id);
        }
    }
}
