using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLNV.Model
{
    public partial class DBnhanvien : DbContext
    {
        public DBnhanvien()
            : base("name=DBnhanvien1")
        {
        }

        public virtual DbSet<ADM> ADMs { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<HopDong> HopDongs { get; set; }
        public virtual DbSet<KhuLam> KhuLams { get; set; }
        public virtual DbSet<Luong> Luongs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChucVu>()
                .HasMany(e => e.NhanViens)
                .WithRequired(e => e.ChucVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HopDong>()
                .HasMany(e => e.NhanViens)
                .WithRequired(e => e.HopDong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhuLam>()
                .HasMany(e => e.NhanViens)
                .WithRequired(e => e.KhuLam)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Luong>()
                .HasMany(e => e.NhanViens)
                .WithRequired(e => e.Luong)
                .WillCascadeOnDelete(false);
        }
    }
}
