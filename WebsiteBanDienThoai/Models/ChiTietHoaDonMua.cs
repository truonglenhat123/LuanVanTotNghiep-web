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
    
    public partial class ChiTietHoaDonMua
    {
        public int maCTHDM { get; set; }
        public Nullable<int> maSP { get; set; }
        public Nullable<double> don_gia { get; set; }
        public Nullable<double> soluong { get; set; }
        public Nullable<int> ma_hoa_don { get; set; }
    
        public virtual SanPham SanPham { get; set; }
    }
}