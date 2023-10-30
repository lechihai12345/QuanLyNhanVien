namespace QLNV.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="! Nhập vào")]
        [StringLength(50)]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "! Nhập vào")]
        [StringLength(50)]
        public string GioiTinh { get; set; }

        [Required(ErrorMessage = "! Nhập vào")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "! Nhập vào")]
        [StringLength(50)]
        public string SoCMND { get; set; }

        [Required(ErrorMessage = "! Nhập vào")]
        [StringLength(50)]
        public string SoDienThoai { get; set; }

        [Required(ErrorMessage = "! Nhập vào")]
        [StringLength(50)]
        public string DiaChi { get; set; }

        public int IDChucVu { get; set; }

        public int IDHopDong { get; set; }

        public int IDLuong { get; set; }

        public int IDKhu { get; set; }

        public int? SoNgayNghi { get; set; }

        [Required(ErrorMessage = "! Nhập vào")]
        [StringLength(50)]
        public string BangCap { get; set; }

        public virtual ChucVu ChucVu { get; set; }

        public virtual HopDong HopDong { get; set; }

        public virtual KhuLam KhuLam { get; set; }

        public virtual Luong Luong { get; set; }
    }
}
