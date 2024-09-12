using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace odevproject.Models
{
    public partial class StajContext : DbContext
    {
        public StajContext(DbContextOptions<StajContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ÖdevTable> ÖdevTables { get; set; }
        public virtual DbSet<Il> Iller { get; set; }
        public virtual DbSet<Ilce> Ilceler { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=staj;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ÖdevTable>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("ödev_table");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.KullaniciAdi)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("kullaniciAdi");
                entity.Property(e => e.KullaniciSoyadi)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("kullaniciSoyadi");
                entity.Property(e => e.Mail)
                    .HasMaxLength(40)
                    .IsUnicode(false);
                entity.Property(e => e.TelefonNumarasi)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("telefonNumarasi");
                entity.Property(e => e.Yas)
                    .HasMaxLength(10)
                    .IsFixedLength();
                entity.Property(e => e.Yetki)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("yetki");

                entity.HasOne(d => d.Il)
                    .WithMany(p => p.ÖdevTables)
                    .HasForeignKey(d => d.IlId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Ilce)
                    .WithMany(p => p.ÖdevTables)
                    .HasForeignKey(d => d.IlceId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Il>(entity =>
            {
                entity.HasKey(e => e.IlId);

                entity.ToTable("iller");

                entity.Property(e => e.IlId).HasColumnName("IlId");
                entity.Property(e => e.IlAd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IlAd");
            });

            modelBuilder.Entity<Ilce>(entity =>
            {
                entity.HasKey(e => e.IlceId);

                entity.ToTable("ilceler");

                entity.Property(e => e.IlceId).HasColumnName("IlceId");
                entity.Property(e => e.IlceAd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IlceAd");
                entity.Property(e => e.IlId).HasColumnName("IlId");

                entity.HasOne(d => d.Il)
                    .WithMany(p => p.Ilceler)
                    .HasForeignKey(d => d.IlId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
