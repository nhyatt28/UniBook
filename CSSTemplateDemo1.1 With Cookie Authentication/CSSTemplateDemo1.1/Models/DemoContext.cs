using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CSSTemplateDemo1._1.Models
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

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=buscissql1901\\cisweb;Database=CIS410_Testing;User ID=robotic;Password=nets;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.DateJoined)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FName).HasMaxLength(50);

                entity.Property(e => e.LName).HasMaxLength(50);

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(15);

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.Street1).HasMaxLength(250);

                entity.Property(e => e.Street2).HasMaxLength(50);

                entity.Property(e => e.ZipCode).HasMaxLength(10);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.Login1);

                entity.Property(e => e.Login1)
                    .HasMaxLength(50)
                    .HasColumnName("Login");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.CustomerID, "IX_Orders_CustomerID");

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerID)
                    .HasConstraintName("FK_Orders_Customers");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasIndex(e => e.ItemID, "IX_OrderItems_ItemID");

                entity.HasIndex(e => e.OrderID, "IX_OrderItems_OrderID");

                entity.Property(e => e.Notes)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ItemID)
                    .HasConstraintName("FK_OrderItems_Items");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderID)
                    .HasConstraintName("FK_OrderItems_Orders");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.FName).HasMaxLength(50);

                entity.Property(e => e.LName).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(15);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
