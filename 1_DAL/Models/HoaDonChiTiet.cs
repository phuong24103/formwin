using System;
using System.Collections.Generic;

namespace _1_DAL.Models
{
    public partial class HoaDonChiTiet
    {
        public Guid IdHoaDon { get; set; }
        public Guid IdChiTietSp { get; set; }
        public int? SoLuong { get; set; }
        public decimal? DonGia { get; set; }

        public virtual ChiTietSp IdChiTietSpNavigation { get; set; } = null!;
        public virtual HoaDon IdHoaDonNavigation { get; set; } = null!;
    }
}
