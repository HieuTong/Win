//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAnCuoiKy
{
    using System;
    using System.Collections.Generic;
    
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            this.ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }
    
        public string MaHoaDon { get; set; }
        public string MaKhachHang { get; set; }
        public string TrangThaiThanhToan { get; set; }
        public Nullable<double> GiamGia { get; set; }
        public Nullable<double> TongTien { get; set; }
        public Nullable<int> Diem { get; set; }
        public Nullable<System.DateTime> NgayLapHoaDon { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual KhachHang KhachHang { get; set; }
    }
}
