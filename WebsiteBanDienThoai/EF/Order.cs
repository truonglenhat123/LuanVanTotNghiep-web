namespace WebsiteBanDienThoai.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Oder_Detail = new HashSet<Oder_Detail>();
        }

        [Key]
        public int order_id { get; set; }

        public int payment_id { get; set; }

        public int delivery_id { get; set; }

        public DateTime oder_date { get; set; }

        public double total { get; set; }

        public int account_id { get; set; }

        [StringLength(1)]
        public string status { get; set; }

        public DateTime create_at { get; set; }

        [Required]
        [StringLength(100)]
        public string create_by { get; set; }

        [Required]
        [StringLength(100)]
        public string update_by { get; set; }

        public DateTime update_at { get; set; }

        [StringLength(200)]
        public string order_note { get; set; }

        public int employee_id { get; set; }

        public int customer_id { get; set; }

        public virtual Account Account { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual employee employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Oder_Detail> Oder_Detail { get; set; }

        public virtual Payment Payment { get; set; }
    }
}
