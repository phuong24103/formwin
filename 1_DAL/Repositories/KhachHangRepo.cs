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
    public class KhachHangRepo : IKhachHangRepo
    {
        FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context _context;
        public KhachHangRepo()
        {
            _context = new FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context();
        }
        public bool Add(KhachHang obj)
        {
            if (obj == null) return false;
            _context.KhachHangs.Add(obj);
            _context.SaveChanges();
            return true;

        }

        public bool Delete(KhachHang obj)
        {
            if (obj == null) return false;
            var del = _context.KhachHangs.FirstOrDefault(p => p.Id == obj.Id);
            _context.KhachHangs.Remove(del);
            _context.SaveChanges();
            return true;
        }

        public List<KhachHang> GetAll()
        {
            return _context.KhachHangs.ToList();
        }

        public bool Update(KhachHang obj)
        {
            if (obj == null) return false;
            var up = _context.KhachHangs.FirstOrDefault(p =>p.Id == obj.Id);
            up.Ma = obj.Ma;
            up.Ten = obj.Ten;
            up.TenDem = obj.TenDem;
            up.Ho = obj.Ho;
            up.NgaySinh = obj.NgaySinh;
            up.DiaChi = obj.DiaChi;
            up.Sdt = obj.Sdt;
            up.MatKhau = obj.MatKhau;
            up.ThanhPho = obj.ThanhPho;
            up.QuocGia = obj.QuocGia;
            _context.Update(up);
            _context.SaveChanges();
            return true;
        }
    }
}
