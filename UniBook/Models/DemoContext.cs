using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UniBook.Models
{
    public partial class DemoContext : DbContext
    {
        public DemoContext()
        {
        }

        public DemoContext(DbContextOptions<DemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Advertisement> Advertisements { get; set; }
        public virtual DbSet<Advertiser> Advertisers { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseMaterial> CourseMaterials { get; set; }
        public virtual DbSet<Listing> Listings { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Textbook> Textbooks { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=buscissql1901\\cisweb;Database=HyattDB;User ID=onlined;Password=banks;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Advertisement>(entity =>
            {
                entity.ToTable("Advertisement");

                entity.Property(e => e.AdvertisementID).ValueGeneratedNever();

                entity.Property(e => e.AdvertisementEnd).HasColumnType("datetime");

                entity.Property(e => e.AdvertisementStart).HasColumnType("datetime");

                entity.Property(e => e.AdvertisementType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Advertiser)
                    .WithMany(p => p.Advertisements)
                    .HasForeignKey(d => d.AdvertiserID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Advertisement_Advertiser");
            });

            modelBuilder.Entity<Advertiser>(entity =>
            {
                entity.ToTable("Advertiser");

                entity.Property(e => e.AdvertiserID).ValueGeneratedNever();

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Industry)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseID).ValueGeneratedNever();

                entity.Property(e => e.CourseDescription).HasMaxLength(250);

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SchoolID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_School");
            });

            modelBuilder.Entity<CourseMaterial>(entity =>
            {
                entity.ToTable("CourseMaterial");

                entity.Property(e => e.CourseMaterialID).ValueGeneratedNever();

                entity.Property(e => e.RequiredText)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.CourseMaterials)
                    .HasForeignKey(d => d.BookID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseMaterial_Textbook");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseMaterials)
                    .HasForeignKey(d => d.CourseID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseMaterial_Course");
            });

            modelBuilder.Entity<Listing>(entity =>
            {
                entity.ToTable("Listing");

                entity.Property(e => e.ListingID).ValueGeneratedNever();

                entity.Property(e => e.ListingDate).HasColumnType("date");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderID).ValueGeneratedNever();

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.ShippingStatus).HasMaxLength(20);

                entity.HasOne(d => d.Boook)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BoookID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Textbook");

                entity.HasOne(d => d.Listing)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ListingID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Listing");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.VendorID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Vendor");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentID).ValueGeneratedNever();

                entity.Property(e => e.PaymentType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.OrderID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Order");
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.ToTable("School");

                entity.Property(e => e.SchoolID).ValueGeneratedNever();

                entity.Property(e => e.SchoolName).HasMaxLength(50);

                entity.Property(e => e.SchoolType).HasMaxLength(15);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentID).ValueGeneratedNever();

                entity.Property(e => e.AddressLine1).HasMaxLength(500);

                entity.Property(e => e.AddressLine2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.DOB).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.LastActivity).HasColumnType("datetime");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.StudentFirstName).HasMaxLength(50);

                entity.Property(e => e.StudentLastName).HasMaxLength(50);

                entity.Property(e => e.StudentType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.SchoolID)
                    .HasConstraintName("FK_Student_School");
            });

            modelBuilder.Entity<Textbook>(entity =>
            {
                entity.HasKey(e => e.BookID);

                entity.ToTable("Textbook");

                entity.Property(e => e.BookID).ValueGeneratedNever();

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Condition)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsFixedLength(true);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Publisher).HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("Vendor");

                entity.Property(e => e.VendorID).ValueGeneratedNever();

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.AddressLine2).HasMaxLength(50);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.ShippingAddress)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<WishList>(entity =>
            {
                entity.ToTable("WishList");

                entity.Property(e => e.WishListID).ValueGeneratedNever();

                entity.HasOne(d => d.CourseMaterial)
                    .WithMany(p => p.WishLists)
                    .HasForeignKey(d => d.CourseMaterialID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WishList_CourseMaterial");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.WishLists)
                    .HasForeignKey(d => d.StudentID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WishList_Student");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
