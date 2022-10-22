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
    
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            this.ChiTietHoaDonBans = new HashSet<ChiTietHoaDonBan>();
            this.ChiTietHoaDonMuas = new HashSet<ChiTietHoaDonMua>();
            this.GioHangs = new HashSet<GioHang>();
        }
    
        public int maSP { get; set; }
        public string ten { get; set; }
        public Nullable<bool> da_xoa { get; set; }
        public Nullable<double> gia_cu { get; set; }
        public Nullable<double> gia_moi { get; set; }
        public string hinh_anh { get; set; }
        public Nullable<bool> hot { get; set; }
        public Nullable<int> ma_danh_muc { get; set; }
        public Nullable<int> maNCC { get; set; }
        public Nullable<System.DateTime> ngay_tao { get; set; }
        public string mota { get; set; }
        public string mausac { get; set; }
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
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDonBan> ChiTietHoaDonBans { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDonMua> ChiTietHoaDonMuas { get; set; }
        public virtual DanhMuc DanhMuc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHangs { get; set; }
        public virtual Kho Kho { get; set; }
        public virtual NhaCungCap NhaCungCap { get; set; }
    }
}