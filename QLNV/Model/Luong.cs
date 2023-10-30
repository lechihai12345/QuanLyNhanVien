namespace QLNV.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Luong")]
    public partial class Luong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Luong()
        {
            NhanViens = new HashSet<NhanVien>();
        }
        [Required(ErrorMessage ="Nhập vào!")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDLuong { get; set; }
        [Required(ErrorMessage ="Nhập vào!")]
        [Range(1000000,100000000,ErrorMessage ="Số lương gốc lơn hơn 1tr vnd")]
        [Display(Name ="Số Lương")]
        public double? SoLuong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
