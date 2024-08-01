using Investimento.Domain._2._2_Entity;
using Microsoft.EntityFrameworkCore;

namespace Investimento.Infra._3._1_Context
{
    public class InvestimentoContext : DbContext 
    {
        public InvestimentoContext(DbContextOptions<InvestimentoContext> options) : base(options) { }

        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>()
               .HasKey(p => new { p.PositionId, p.Date });
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_BIN");            
        }
    }
}
