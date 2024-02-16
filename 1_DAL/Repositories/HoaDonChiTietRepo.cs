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
    public class HoaDonChiTietRepo : IHoaDonChiTietRepo

    {
        FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context _context;
        public HoaDonChiTietRepo()
        {
            _context = new FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context();
        }
        public bool Add(HoaDonChiTiet obj)
        {
            if(obj == null) return false;
            _context.HoaDonChiTiets.Add(obj);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(HoaDonChiTiet obj)
        {
            if (obj == null) return false;
            var del = _context.HoaDonChiTiets.FirstOrDefault(p => p.IdHoaDon == obj.IdHoaDon);
            _context.HoaDonChiTiets.Remove(del);
            _context.SaveChanges();
            return true;
        }

        public List<HoaDonChiTiet> GetAll()
        {
            return _context.HoaDonChiTiets.ToList();
        }

        public bool Update(HoaDonChiTiet obj)
        {
            if (obj == null) return false;
            var up = _context.HoaDonChiTiets.FirstOrDefault(p => p.IdHoaDon == obj.IdHoaDon);
            up.IdChiTietSp = obj.IdChiTietSp;
            up.SoLuong = obj.SoLuong;
            up.DonGia = obj.DonGia;
            _context.Update(up);
            _context.SaveChanges();
            return true;
        }
    }
}
