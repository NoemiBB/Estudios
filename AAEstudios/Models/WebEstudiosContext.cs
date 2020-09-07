using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AAEstudios.Models
{
    public partial class WebEstudiosContext : DbContext
    {
        public WebEstudiosContext()
        {
        }

        public WebEstudiosContext(DbContextOptions<WebEstudiosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumnos> Alumnos { get; set; }
        public virtual DbSet<Asignaturas> Asignaturas { get; set; }
        public virtual DbSet<Examenes> Examenes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // Directiva #warning
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-7I1FFPL\\SQLEXPRESS19;Database=WebEstudios;Integrated Security=true");
#pragma warning restore CS1030 // Directiva #warning
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumnos>(entity =>
            {
                entity.HasKey(e => e.AlumnoId);

                entity.Property(e => e.AlumnoId).HasColumnName("alumnoId");

                entity.Property(e => e.AlumnoNombre)
                    .IsRequired()
                    .HasColumnName("alumnoNombre")
                    .HasMaxLength(25)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Asignaturas>(entity =>
            {
                entity.HasKey(e => e.AsignaturaId);

                entity.Property(e => e.AsignaturaId)
                    .HasColumnName("asignaturaId")
                    .ValueGeneratedNever();

                entity.Property(e => e.AsignaturaColor)
                    .HasColumnName("asignaturaColor")
                    .HasMaxLength(6)
                    .IsFixedLength();

                entity.Property(e => e.AsignaturaNombre)
                    .IsRequired()
                    .HasColumnName("asignaturaNombre")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Examenes>(entity =>
            {
                entity.HasKey(e => new { e.AlumnoId, e.AsignaturaId, e.Fecha });

                entity.Property(e => e.AlumnoId).HasColumnName("alumnoId");

                entity.Property(e => e.AsignaturaId).HasColumnName("asignaturaId");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.Nota)
                    .HasColumnName("nota")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Observaciones)
                    .HasColumnName("observaciones")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tema)
                    .HasColumnName("tema")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Alumno)
                    .WithMany(p => p.Examenes)
                    .HasForeignKey(d => d.AlumnoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Examenes_Alumnos");

                entity.HasOne(d => d.Asignatura)
                    .WithMany(p => p.Examenes)
                    .HasForeignKey(d => d.AsignaturaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Examenes_Asignaturas");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
