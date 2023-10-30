namespace QLNV.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("HopDong")]
    public partial class HopDong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HopDong()
        {
            NhanViens = new HashSet<NhanVien>();
        }
        [Required(ErrorMessage = "Nhập vào!")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID Hợp Đồng")]
        public int IDhopDong { get; set; }
        [Display(Name = "Tên Hợp Đồng")]
        [StringLength(50)]
        [Required(ErrorMessage ="Nhập vào")]
        public string TenHopDong { get; set; }
        [Display(Name = "Loại Hợp Đồng")]
        [Required(ErrorMessage = "Nhập vào")]
        [StringLength(10)]
        public string LoaiHD { get; set; }
        [Display(Name = "Nội Dung")]
        [Required(ErrorMessage = "Nhập vào")]
        [StringLength(200)]
        public string NoiDung { get; set; }
        [Display(Name = "Ngày Ký")]
        [Required(ErrorMessage = "Nhập vào")]
        [StringLength(50)]
        public String TimeK { get; set; } 
        [Display(Name = "Ngày Kết Thúc")]
        [Required(ErrorMessage = "Nhập vào")]
        [StringLength(50)]
        public String TimeKT { get; set; }
        [Display(Name = "Ngày Bắt Đầu Làm")]
        [Required(ErrorMessage = "Nhập vào")]
        [StringLength(50)]
        public String NgayStart { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
