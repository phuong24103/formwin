using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.ViewModels
{
    public class HoaDonChiTietView
    {
        public ChiTietSp ChiTietSp { get; set; }
        public HoaDon HoaDon { get; set; }

        public HoaDonChiTiet HoaDonChiTiet { get; set; }
    }
}
