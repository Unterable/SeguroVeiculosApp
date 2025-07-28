using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SeguroContext : DbContext
    {
        public SeguroContext(DbContextOptions<SeguroContext> options) : base(options)
        {
        }

        public DbSet<Seguro> Seguros { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Segurado> Segurados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seguro>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TaxaRisco).HasColumnType("decimal(18,4)");
                entity.Property(e => e.PremioRisco).HasColumnType("decimal(18,2)");
                entity.Property(e => e.PremioPuro).HasColumnType("decimal(18,2)");
                entity.Property(e => e.PremioComercial).HasColumnType("decimal(18,2)");
                entity.Property(e => e.ValorSeguro).HasColumnType("decimal(18,2)");
                
                entity.HasOne(e => e.Veiculo)
                      .WithMany()
                      .HasForeignKey("VeiculoId")
                      .OnDelete(DeleteBehavior.Restrict);
                
                entity.HasOne(e => e.Segurado)
                      .WithMany()
                      .HasForeignKey("SeguradoId")
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Valor).HasColumnType("decimal(18,2)");
                entity.Property(e => e.MarcaModelo).HasMaxLength(200).IsRequired();
            });

            modelBuilder.Entity<Segurado>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).HasMaxLength(200).IsRequired();
                entity.Property(e => e.CPF).HasMaxLength(11).IsRequired();
                entity.Property(e => e.Idade).IsRequired();
            });
        }
    }
}

