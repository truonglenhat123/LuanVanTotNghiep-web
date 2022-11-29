using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteBanDienThoai.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<double> Old_Price { get; set; }
        public Nullable<double> New_Price { get; set; }
        public string image { get; set; }
        public Nullable<bool> hot { get; set; }
        public int genre_id { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string Description { get; set; }
        public string Descriptionshort { get; set; }
        public string Color { get; set; }
        public string kichThuocManHinh { get; set; }
        public string dophangiaiManHinh { get; set; }
        public string bonhotrong { get; set; }
        public string cameraTruoc { get; set; }
        public string cameraSau { get; set; }
        public string ram { get; set; }
        public string pin { get; set; }
        public string sim { get; set; }
        public string heDieuHanh { get; set; }
        public string CPU { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<int> brand_id { get; set; }
        public string status { get; set; }
        public string create_by { get; set; }
        public Nullable<System.DateTime> create_at { get; set; }
        public int disscount_id { get; set; }

       
    }
}