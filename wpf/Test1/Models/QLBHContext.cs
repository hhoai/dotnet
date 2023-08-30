using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Test1.Models
{
    public partial class QLBHContext : DbContext
    {
        public QLBHContext()
        {
        }

        public QLBHContext(DbContextOptions<QLBHContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Nhap> Nhaps { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }
        public virtual DbSet<Xuat> Xuats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=HUYNHHOAI\\SQLEXPRESS;Initial Catalog=QLBH;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Nhap>(entity =>
            {
                entity.HasKey(e => new { e.Sohdn, e.Masp })
                    .HasName("PK__nhap__289493ECF1D1DAD4");

                entity.ToTable("nhap");

                entity.Property(e => e.Sohdn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sohdn")
                    .IsFixedLength(true);

                entity.Property(e => e.Masp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("masp")
                    .IsFixedLength(true);

                entity.Property(e => e.Dongia).HasColumnName("dongia");

                entity.Property(e => e.Ngayn)
                    .HasColumnType("date")
                    .HasColumnName("ngayn");

                entity.Property(e => e.Soluongn).HasColumnName("soluongn");
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.HasKey(e => e.Masp)
                    .HasName("PK__sanpham__7A2176720E9E1E08");

                entity.ToTable("sanpham");

                entity.Property(e => e.Masp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("masp")
                    .IsFixedLength(true);

                entity.Property(e => e.Dongia).HasColumnName("dongia");

                entity.Property(e => e.Mausac)
                    .HasMaxLength(20)
                    .HasColumnName("mausac");

                entity.Property(e => e.Soluong).HasColumnName("soluong");

                entity.Property(e => e.Tensp)
                    .HasMaxLength(30)
                    .HasColumnName("tensp");
            });

            modelBuilder.Entity<Xuat>(entity =>
            {
                entity.HasKey(e => new { e.Sohdx, e.Masp })
                    .HasName("PK__xuat__289493925999B9B8");

                entity.ToTable("xuat");

                entity.Property(e => e.Sohdx)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sohdx")
                    .IsFixedLength(true);

                entity.Property(e => e.Masp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("masp")
                    .IsFixedLength(true);

                entity.Property(e => e.Ngayx)
                    .HasColumnType("date")
                    .HasColumnName("ngayx");

                entity.Property(e => e.Soluongx).HasColumnName("soluongx");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
