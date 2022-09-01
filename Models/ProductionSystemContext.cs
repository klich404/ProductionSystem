using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProductionSystem.Models
{
    public partial class ProductionSystemContext : DbContext
    {
        public ProductionSystemContext()
        {
        }

        public ProductionSystemContext(DbContextOptions<ProductionSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Color> Color { get; set; } = null!;
        public virtual DbSet<Inventario> Inventario { get; set; } = null!;
        public virtual DbSet<MateriaPrima> MateriaPrima { get; set; } = null!;
        public virtual DbSet<OrdenProduccion> OrdenProduccion { get; set; } = null!;
        public virtual DbSet<Prendum> Prenda { get; set; } = null!;
        public virtual DbSet<TipoTela> TipoTelas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-3ROOGOC; Database=ProductionSystem; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("Color");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.Consecutivo)
                    .HasName("PK__Inventar__AB810F67E0C583B1");

                entity.ToTable("Inventario");

                entity.HasOne(d => d.MateriaPrimaNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.MateriaPrima)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MateriaPrima");
            });

            modelBuilder.Entity<MateriaPrima>(entity =>
            {
                entity.ToTable("MateriaPrima");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.ColorNavigation)
                    .WithMany(p => p.MateriaPrimas)
                    .HasForeignKey(d => d.Color)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Color");

                entity.HasOne(d => d.TelaNavigation)
                    .WithMany(p => p.MateriaPrimas)
                    .HasForeignKey(d => d.Tela)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tela");
            });

            modelBuilder.Entity<OrdenProduccion>(entity =>
            {
                entity.HasKey(e => e.Consecutivo)
                    .HasName("PK__OrdenPro__AB810F673430D38C");

                entity.ToTable("OrdenProduccion");

                entity.HasOne(d => d.MateriaPrimaNavigation)
                    .WithMany(p => p.OrdenProduccions)
                    .HasForeignKey(d => d.MateriaPrima)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MateriaPrimaOP");

                entity.HasOne(d => d.PrendaNavigation)
                    .WithMany(p => p.OrdenProduccions)
                    .HasForeignKey(d => d.Prenda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prenda");
            });

            modelBuilder.Entity<Prendum>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoTela>(entity =>
            {
                entity.ToTable("TipoTela");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
