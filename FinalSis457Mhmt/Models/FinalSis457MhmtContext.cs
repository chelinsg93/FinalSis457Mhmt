using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FinalSis457Mhmt.Models
{
    public partial class FinalSis457MhmtContext : DbContext
    {
        public FinalSis457MhmtContext()
        {
        }

        public FinalSis457MhmtContext(DbContextOptions<FinalSis457MhmtContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Serie> Series { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FinalSis457Mhmt;User ID=usrfinal1;Password=12345678");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Serie>(entity =>
            {
                entity.ToTable("Serie");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Director)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("director");

                entity.Property(e => e.Duracion).HasColumnName("duracion");

                entity.Property(e => e.FechaEstreno)
                    .HasColumnType("date")
                    .HasColumnName("fechaEstreno");

                entity.Property(e => e.RegistroActivo)
                    .HasColumnName("registroActivo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Sinopsis)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("sinopsis");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.Property(e => e.UsuarioRegistro)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("usuarioRegistro")
                    .HasDefaultValueSql("(suser_sname())");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clave)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("clave");

                entity.Property(e => e.RegistroActivo)
                    .HasColumnName("registroActivo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Rol)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("rol");

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
