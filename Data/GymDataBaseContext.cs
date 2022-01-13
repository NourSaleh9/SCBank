using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SCBankGym.Data
{
    public partial class GymDataBaseContext : DbContext
    {
        public GymDataBaseContext()
        {
        }

        public GymDataBaseContext(DbContextOptions<GymDataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContactU> ContactUs { get; set; } = null!;
        public virtual DbSet<Trainee> Trainees { get; set; } = null!;
        public virtual DbSet<Trainer> Trainers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-R67K0GM;Initial Catalog=GymDataBase;user id=sa;password=123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactU>(entity =>
            {
                entity.HasKey(e => e.ContactUsId);

                entity.Property(e => e.ContactUsId).HasColumnName("ContactUsID");

                entity.Property(e => e.Message).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.TrineeId).HasColumnName("TrineeID");

                entity.HasOne(d => d.Trinee)
                    .WithMany(p => p.ContactUs)
                    .HasForeignKey(d => d.TrineeId)
                    .HasConstraintName("FK_ContactUs_trainee");
            });

            modelBuilder.Entity<Trainee>(entity =>
            {
                entity.ToTable("trainee");

                entity.Property(e => e.TraineeId).HasColumnName("TraineeID");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.Class)
                    .HasMaxLength(50)
                    .HasColumnName("class");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("firstName");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .HasColumnName("gender");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("lastName");

                entity.Property(e => e.Passwordd)
                    .HasMaxLength(10)
                    .HasColumnName("passwordd");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("phone");

                entity.Property(e => e.Photo)
                    .HasMaxLength(50)
                    .HasColumnName("photo");

                entity.Property(e => e.Subscription).HasMaxLength(50);
            });

            modelBuilder.Entity<Trainer>(entity =>
            {
                entity.ToTable("trainer");

                entity.Property(e => e.TrainerId).HasColumnName("TrainerID");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Dayss)
                    .HasMaxLength(50)
                    .HasColumnName("dayss");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .HasColumnName("gender");

                entity.Property(e => e.HoursFrom)
                    .HasMaxLength(50)
                    .HasColumnName("hoursFROM");

                entity.Property(e => e.HoursTo)
                    .HasMaxLength(50)
                    .HasColumnName("hoursTO");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Passwordd)
                    .HasMaxLength(10)
                    .HasColumnName("passwordd");

                entity.Property(e => e.Photo)
                    .HasMaxLength(50)
                    .HasColumnName("photo");

                entity.Property(e => e.TraineeId).HasColumnName("traineeID");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.Trainers)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_trainer_trainee");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
