namespace WebsiteBanDienThoai.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact
    {
        [Key]
        public int contact_id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string phone { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string content { get; set; }

        [Required]
        [StringLength(20)]
        public string create_by { get; set; }

        public DateTime create_at { get; set; }

        [Required]
        [StringLength(1)]
        public string status { get; set; }

        [Required]
        [StringLength(20)]
        public string update_by { get; set; }

        public DateTime? update_at { get; set; }
    }
}
