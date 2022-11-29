namespace WebsiteBanDienThoai.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Replyfeedback")]
    public partial class Replyfeedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int rep_feedback_id { get; set; }

        public string content { get; set; }

        [StringLength(1)]
        public string stastus { get; set; }

        public DateTime create_at { get; set; }

        public int feedback_id { get; set; }

        public int account_id { get; set; }

        public virtual Account Account { get; set; }

        public virtual Feedback Feedback { get; set; }
    }
}
