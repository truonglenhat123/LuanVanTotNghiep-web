namespace WebsiteBanDienThoai.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Payment()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int payment_id { get; set; }

        [Required]
        [StringLength(50)]
        public string payment_name { get; set; }

        public DateTime create_at { get; set; }

        [Required]
        [StringLength(20)]
        public string create_by { get; set; }

        [StringLength(1)]
        public string status { get; set; }

        [Required]
        [StringLength(20)]
        public string update_by { get; set; }

        public DateTime? update_at { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}