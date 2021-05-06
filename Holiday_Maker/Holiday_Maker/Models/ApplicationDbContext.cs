using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Holiday_Maker.Models
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accomodation> Accomodations { get; set; }
        public virtual DbSet<AccomodationType> AccomodationTypes { get; set; }
        public virtual DbSet<Amenity> Amenities { get; set; }
        public virtual DbSet<Extra> Extras { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=holidaymakerz.database.windows.net;Initial Catalog=HolidayMaker;User ID=storapappa;Password=grupp4123!!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Accomodation>(entity =>
            {
                entity.ToTable("Accomodation");

                entity.HasIndex(e => e.Id, "IX_Accomodation")
                    .IsUnique();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.GuestRating).HasColumnType("decimal(10, 1)");

                entity.Property(e => e.ImgSrc)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.AccomodationType)
                    .WithMany(p => p.Accomodations)
                    .HasForeignKey(d => d.AccomodationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Accomodation_AccomodationType");
            });

            modelBuilder.Entity<AccomodationType>(entity =>
            {
                entity.ToTable("AccomodationType");

                entity.Property(e => e.AccomodationType1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("AccomodationType");
            });

            modelBuilder.Entity<Amenity>(entity =>
            {
                entity.ToTable("Amenity");

                entity.HasOne(d => d.Accomodation)
                    .WithMany(p => p.Amenities)
                    .HasForeignKey(d => d.AccomodationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Amenity_Accomodation");
            });

            modelBuilder.Entity<Extra>(entity =>
            {
                entity.ToTable("Extra");

                entity.HasOne(d => d.Accomodation)
                    .WithMany(p => p.Extras)
                    .HasForeignKey(d => d.AccomodationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Extra_Accomodation");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.ImgSrc).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Accomodation)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.AccomodationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_Accomodation");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_RoomType");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.ToTable("RoomType");

                entity.Property(e => e.RoomType1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("RoomType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
