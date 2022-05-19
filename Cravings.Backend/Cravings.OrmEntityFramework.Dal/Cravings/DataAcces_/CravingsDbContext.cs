using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Cravings.DataAccess
{
    public partial class CravingsDbContext : DbContext
    {
        public CravingsDbContext()
        {
        }

        public CravingsDbContext(DbContextOptions<CravingsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AntoCliente> AntoClientes { get; set; }
        public virtual DbSet<AntoDetalleVentum> AntoDetalleVenta { get; set; }
        public virtual DbSet<AntoInventario> AntoInventarios { get; set; }
        public virtual DbSet<AntoProducto> AntoProductos { get; set; }
        public virtual DbSet<AntoVentum> AntoVenta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // #advertencia: 'To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.'
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ANTOJITOS;Trusted_Connection=True;");
#pragma warning restore CS1030 // #advertencia: 'To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.'
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<AntoCliente>(entity =>
            {
                entity.HasKey(e => e.ConsCliente)
                    .HasName("ANTO_CLIENTE_PK");

                entity.Property(e => e.ConsCliente).ValueGeneratedNever();

                entity.Property(e => e.DireccionResidencial).IsUnicode(false);

                entity.Property(e => e.DireccionTrabajo).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PrimerApellido).IsUnicode(false);

                entity.Property(e => e.PrimerNombre).IsUnicode(false);

                entity.Property(e => e.SegundoApellido).IsUnicode(false);

                entity.Property(e => e.SegundoNombre).IsUnicode(false);

                entity.Property(e => e.TelefonoCelular).IsUnicode(false);

                entity.Property(e => e.TelefonoFijo).IsUnicode(false);
            });

            modelBuilder.Entity<AntoDetalleVentum>(entity =>
            {
                entity.HasKey(e => new { e.ConsVenta, e.ConsProducto })
                    .HasName("ANTO_DETALLE_VENTA_PK");

                entity.Property(e => e.Estado)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ConsProductoNavigation)
                    .WithMany(p => p.AntoDetalleVenta)
                    .HasForeignKey(d => d.ConsProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ANTO_DETALLE_VENTA_FK_02");

                entity.HasOne(d => d.ConsVentaNavigation)
                    .WithMany(p => p.AntoDetalleVenta)
                    .HasForeignKey(d => d.ConsVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ANTO_DETALLE_VENTA_FK_01");
            });

            modelBuilder.Entity<AntoInventario>(entity =>
            {
                entity.HasKey(e => e.ConsInventario)
                    .HasName("ANTO_INVENTARIO_PK");

                entity.Property(e => e.ConsInventario).ValueGeneratedNever();

                entity.Property(e => e.Estado)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ConsProductoNavigation)
                    .WithMany(p => p.AntoInventarios)
                    .HasForeignKey(d => d.ConsProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ANTO_INVENTARIO_FK_01");
            });

            modelBuilder.Entity<AntoProducto>(entity =>
            {
                entity.HasKey(e => e.ConsProducto)
                    .HasName("ANTO_PRODUCTO_PK");

                entity.Property(e => e.ConsProducto).ValueGeneratedNever();

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<AntoVentum>(entity =>
            {
                entity.HasKey(e => e.ConsVenta)
                    .HasName("ANTO_VENTA_PK");

                entity.Property(e => e.ConsVenta).ValueGeneratedNever();

                entity.Property(e => e.Estado)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ConsClienteNavigation)
                    .WithMany(p => p.AntoVenta)
                    .HasForeignKey(d => d.ConsCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ANTO_VENTA_FK_01");
            });

            modelBuilder.HasSequence<int>("ANTO_CLIENTE_SEQ").HasMin(1);

            modelBuilder.HasSequence<int>("ANTO_INVENTARIO_SEQ").HasMin(1);

            modelBuilder.HasSequence<int>("ANTO_PRODUCTO_SEQ").HasMin(1);

            modelBuilder.HasSequence<int>("ANTO_VENTA_SEQ").HasMin(1);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
