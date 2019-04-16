using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Core.Contexts
{
    public class ThermalNetworksDBContext : DbContext
    {
        public ThermalNetworksDBContext(DbContextOptions<ThermalNetworksDBContext> options) : base(options) { }
        public DbSet<SteelPipe> SteelPipes { get; set; }
        public DbSet<PipelineSection> PipelineSections { get; set; }
        public DbSet<TypeOfNode> TypeOfNodes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PipelineSection>()
                .HasOne(p => p.SteelPipe)
                .WithMany(t => t.PipelineSections)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ThermalNode>()
                .HasOne(p => p.TypeOfNode)
                .WithMany(t => t.ThermalNodes)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<InitialNode>()
                .HasKey(t => new { t.Id });

            modelBuilder.Entity<EndNode>()
                .HasKey(t => new { t.Id });

            //modelBuilder.Entity<SectionSupport>()
            //.HasKey (t => new { t.Id });

            //modelBuilder.Entity<SectionSupport>()
            //    .HasOne(p => p.PipelineSection)
            //    .WithMany(t => t.SectionSupports)
            //    .HasForeignKey(sc => sc.PipelineSectionId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<SectionSupport>()
            //    .HasOne(p => p.InitialNode)
            //    .WithMany(t => t.SectionSupports)
            //    .HasForeignKey(sc => sc.InitialNodeId)
            //    .OnDelete(DeleteBehavior.Cascade); 

            //modelBuilder.Entity<SectionSupport>()
            //    .HasOne(p => p.EndNode)
            //    .WithMany(t => t.SectionSupports)
            //    .HasForeignKey(sc => sc.EndNodeId)
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ThermalNode>()
               .HasOne(p => p.ThermalNetwork)
               .WithMany(t => t.ThermalNodes)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ThermalNetwork>()
                .HasOne(p => p.Organization)
                .WithMany(t => t.ThermalNetworks)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrganizationM>()
                .HasOne(p => p.ManagementBody)
                .WithMany(t => t.Organizations)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
