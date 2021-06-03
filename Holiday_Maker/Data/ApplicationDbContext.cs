using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Holiday_Maker.Models;

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
        public virtual DbSet<BookedRoom> BookedRooms { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Extra> Extras { get; set; }
        public virtual DbSet<MemberType> MemberTypes { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserFavorite> UserFavorites { get; set; }
        public virtual DbSet<UserRating> UserRatings { get; set; }
        public virtual DbSet<WifiQuality> WifiQualities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
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

                entity.Property(e => e.GuestRating).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.ImgSrc)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ThemeType).HasMaxLength(100);

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

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
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

            modelBuilder.Entity<BookedRoom>(entity =>
            {
                entity.ToTable("BookedRoom");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookedRooms)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookedRoom_Booking");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.Property(e => e.CancellationDate).HasColumnType("datetime");

                entity.Property(e => e.CheckInDate).HasColumnType("datetime");

                entity.Property(e => e.CheckOutDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");
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

            modelBuilder.Entity<MemberType>(entity =>
            {
                entity.ToTable("MemberType");

                entity.Property(e => e.MemberType1)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("MemberType");
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

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StreetAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<UserFavorite>(entity =>
            {
                entity.ToTable("UserFavorite");

                entity.Property(e => e.GroupName).HasMaxLength(50);
            });

            modelBuilder.Entity<UserRating>(entity =>
            {
                entity.ToTable("UserRating");

                entity.Property(e => e.AccomodationId).HasColumnName("AccomodationID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Accomodation)
                    .WithMany(p => p.UserRatings)
                    .HasForeignKey(d => d.AccomodationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRating_Accomodation");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRatings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRating_User1");
            });

            modelBuilder.Entity<WifiQuality>(entity =>
            {
                entity.ToTable("WifiQuality");

                entity.Property(e => e.Mbps).HasColumnType("decimal(4, 1)");

                entity.HasOne(d => d.Amenity)
                    .WithMany(p => p.WifiQualities)
                    .HasForeignKey(d => d.AmenityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WifiQuality_Amenity");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
