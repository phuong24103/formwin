using System;
using System.Collections.Generic;

namespace _1_DAL.Models
{
    public partial class GioHangChiTiet
    {
        public Guid IdGioHang { get; set; }
        public Guid IdChiTietSp { get; set; }
        public int? SoLuong { get; set; }
        public decimal? DonGia { get; set; }
        public decimal? DonGiaKhiGiam { get; set; }

        public virtual ChiTietSp IdChiTietSpNavigation { get; set; } = null!;
        public virtual GioHang IdGioHangNavigation { get; set; } = null!;
    }
}
