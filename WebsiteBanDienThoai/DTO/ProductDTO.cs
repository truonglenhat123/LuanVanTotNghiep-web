using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebsiteBanDienThoai.EF;

namespace WebsiteBanDienThoai.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public bool? IsDelete { get; set; }

        public double? Old_Price { get; set; }
        public string genre_name { get; set; }
        public string brand_name { get; set; }

        public double? New_Price { get; set; }


        public string image { get; set; }

        public bool? hot { get; set; }

        public int genre_id { get; set; }

        public int? SupplierID { get; set; }

        public DateTime? CreateDate { get; set; }

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

        public int? SoLuong { get; set; }

        public int? brand_id { get; set; }


        public string status { get; set; }


        public string create_by { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? create_at { get; set; }

        public int disscount_id { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual Discount Discount { get; set; }


        public virtual Genre Genre { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}