using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.ViewModels
{
    public class Ctsp_view
    {
        public Guid Id { get; set; }

        public Guid? IdSp { get; set; }
        public string? MoTa { get; set; }
        public string? TenSp { get; set; }
        public int? SoLuongTon { get; set; }
        public decimal? GiaNhap { get; set; }
        public decimal? GiaBan { get; set; }
        public decimal? GiaTriTon { get; set; }
    }
}
