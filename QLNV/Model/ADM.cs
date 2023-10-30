namespace QLNV.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("ADM")]
    public partial class ADM
    {
        [Key]
        public int IDadm { get; set; }
        [StringLength(50)]
        [Display(Name ="Tên Đăng Nhập")]
        public string TenDN { get; set; }
       
        [Display(Name = "Mật Khẩu")]
       
        [StringLength(50)]
        public string Pass { get; set; }
      
    }
}
