namespace QLNV.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhuLam")]
    public partial class KhuLam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhuLam()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        [Key]
        public int IDKhu { get; set; }
        [Display(Name ="Tên Khu")]
        [Required(ErrorMessage ="! Nhập vào")]
        [StringLength(50)]
        public string TenKhu { get; set; }
       

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
