namespace WebsiteBanDienThoai.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Feedbacks = new HashSet<Feedback>();
            Oder_Detail = new HashSet<Oder_Detail>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public bool? IsDelete { get; set; }

        public double Old_Price { get; set; }

        public double New_Price { get; set; }

        [StringLength(500)]
        public string image { get; set; }

        public bool? hot { get; set; }

        public int genre_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public string Description { get; set; }

        public string Descriptionshort { get; set; }

        [StringLength(10)]
        public string Color { get; set; }

        [StringLength(500)]
        public string kichThuocManHinh { get; set; }

        [StringLength(500)]
        public string dophangiaiManHinh { get; set; }

        [StringLength(500)]
        public string bonhotrong { get; set; }

        [StringLength(500)]
        public string cameraTruoc { get; set; }

        [StringLength(500)]
        public string cameraSau { get; set; }

        [StringLength(500)]
        public string ram { get; set; }

        [StringLength(500)]
        public string pin { get; set; }

        [StringLength(500)]
        public string sim { get; set; }

        [StringLength(500)]
        public string heDieuHanh { get; set; }

        [StringLength(500)]
        public string CPU { get; set; }

        public int? SoLuong { get; set; }

        public int? brand_id { get; set; }

        [StringLength(1)]
        public string status { get; set; }

        [StringLength(20)]
        public string create_by { get; set; }

        [Column(TypeName = "date")]
        public DateTime? create_at { get; set; }

        public int disscount_id { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual Discount Discount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        public virtual Genre Genre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Oder_Detail> Oder_Detail { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
        [NotMapped]
        public HttpPostedFileBase[] ImageUploadMulti { get; set; }
    }
}
