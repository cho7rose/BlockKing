using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlockKing.Detail
{
    public partial class BlockKingDbContext : DbContext
    {
        /*public BlockKingDbContext()
        {
        }*/

        public BlockKingDbContext(DbContextOptions<BlockKingDbContext> options) : base(options)
        {
        }

        public virtual DbSet<BuildingDefenses> BuildingDefenses { get; set; }
        public virtual DbSet<Buildings> Buildings { get; set; }
        public virtual DbSet<Occupations> Occupations { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<Weapons> Weapons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuildingDefenses>(entity =>
            {
                entity.HasKey(e => e.DefenseId)
                    .HasName("PRIMARY");

                entity.ToTable("building_defenses");

                entity.Property(e => e.DefenseId).HasColumnName("DefenseID");

                entity.Property(e => e.Icon)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Buildings>(entity =>
            {
                entity.HasKey(e => e.BuildingId)
                    .HasName("PRIMARY");

                entity.ToTable("buildings");

                entity.HasIndex(e => e.DefenseId)
                    .HasName("DefenseID");

                entity.Property(e => e.BuildingId).HasColumnName("BuildingID");

                entity.Property(e => e.DefenseId).HasColumnName("DefenseID");

                entity.Property(e => e.Icon)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.XLocation).HasColumnName("xLocation");

                entity.Property(e => e.YLocation).HasColumnName("yLocation");

                entity.HasOne(d => d.Defense)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.DefenseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("buildings_ibfk_1");
            });

            modelBuilder.Entity<Occupations>(entity =>
            {
                entity.HasKey(e => e.WorkId)
                    .HasName("PRIMARY");

                entity.ToTable("occupations");

                entity.Property(e => e.WorkId).HasColumnName("WorkID");

                entity.Property(e => e.Icon)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<People>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("PRIMARY");

                entity.ToTable("people");

                entity.HasIndex(e => e.BuildingId)
                    .HasName("BuildingID");

                entity.HasIndex(e => e.WeaponId)
                    .HasName("WeaponID");

                entity.HasIndex(e => e.WorkId)
                    .HasName("WorkID");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.BuildingId).HasColumnName("BuildingID");

                entity.Property(e => e.Icon)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.WeaponId).HasColumnName("WeaponID");

                entity.Property(e => e.WorkId).HasColumnName("WorkID");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.BuildingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("people_ibfk_1");

                entity.HasOne(d => d.Weapon)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.WeaponId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("people_ibfk_2");

                entity.HasOne(d => d.Work)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.WorkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("people_ibfk_3");
            });

            modelBuilder.Entity<Weapons>(entity =>
            {
                entity.HasKey(e => e.WeaponId)
                    .HasName("PRIMARY");

                entity.ToTable("weapons");

                entity.Property(e => e.WeaponId).HasColumnName("WeaponID");

                entity.Property(e => e.Icon)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
