//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebsiteBanDienThoai.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GioHang
    {
        public int maGioHang { get; set; }
        public string tk { get; set; }
        public Nullable<int> maSP { get; set; }
        public Nullable<int> soLuong { get; set; }
        public Nullable<double> tongtien { get; set; }
    
        public virtual SanPham SanPham { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
