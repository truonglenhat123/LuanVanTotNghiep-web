using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebsiteBanDienThoai.EF;

namespace WebsiteBanDienThoai.Models
{
    public class OrderModel
    {
        public int order_id { get; set; }

        public int? payment_id { get; set; }

        public DateTime? oder_date { get; set; }

        public double total { get; set; }

        public int account_id { get; set; }

        public string status { get; set; }

        public DateTime create_at { get; set; }

        public string create_by { get; set; }

        public string update_by { get; set; }

        public DateTime update_at { get; set; }

        public string order_note { get; set; }

        public int employee_id { get; set; }

        public int customer_id { get; set; }
        public string addressShipping { get; set; }

        public string phoneShipping { get; set; }

        public virtual Account Account { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual employee employee { get; set; }

        public virtual ICollection<Oder_Detail> Oder_Detail { get; set; }

        public virtual Payment Payment { get; set; }

    }
}