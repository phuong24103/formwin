using _1_DAL.IRepositories;
using _1_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Repositories
{
    public class HoaDonRepo : IHoaDonRepo
    {
        FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context _context;
        public HoaDonRepo()
        {
            _context = new FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context();
        }
        public bool Add(HoaDon obj)
        {
            if (obj == null) return false;
            _context.HoaDons.Add(obj);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(HoaDon obj)
        {
            if (obj == null) return false;
            var del = _context.HoaDons.FirstOrDefault(p => p.Id == obj.Id);
            _context.HoaDons.Remove(del);
            _context.SaveChanges();
            return true;
        }

        public List<HoaDon> GetAll()
        {
            return _context.HoaDons.ToList();
        }

        public bool Update(HoaDon obj)
        {
            if (obj == null) return false;
            var up = _context.HoaDons.FirstOrDefault(p => p.Id == obj.Id);
            up.IdKh = obj.IdKh;
            up.IdNv = obj.IdNv;
            up.Ma = obj.Ma;
            up.NgayTao = obj.NgayTao;
            up.NgayThanhToan = obj.NgayThanhToan;
            up.NgayShip = obj.NgayShip;
            up.NgayNhan = obj.NgayNhan;
            up.TinhTrang = obj.TinhTrang;
            up.TenNguoiNhan = obj.TenNguoiNhan;
            up.DiaChi = obj.DiaChi;
            up.Sdt = obj.Sdt;
            _context.Update(up);
            _context.SaveChanges();
            return true;
        }
    }
}
