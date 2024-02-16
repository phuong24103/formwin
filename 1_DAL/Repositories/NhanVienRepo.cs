using _1_DAL.IRepositories;
using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Repositories
{
    public class NhanVienRepo : INhanVienRepo
    {
        FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context _context;
        public NhanVienRepo()
        {
            _context = new FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context();
        }
        public bool Add(NhanVien obj)
        {
            if(obj == null) return false;
            _context.NhanViens.Add(obj);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(NhanVien obj)
        {
            if(null == obj) return false;
            var del = _context.NhanViens.FirstOrDefault(p => p.Id == obj.Id);
            _context.NhanViens.Remove(del);
            _context.SaveChanges();
            return true;
        }

        public List<NhanVien> GetAll()
        {
            return _context.NhanViens.ToList();
        }

        public bool Update(NhanVien obj)
        {
            if (obj == null) return false;
            var up = _context.NhanViens.FirstOrDefault(p => p.Id == obj.Id);
            up.Ma = obj.Ma;
            up.Ten = obj.Ten;
            up.TenDem = obj.TenDem;
            up.Ho = obj.Ho;
            up.GioiTinh = obj.GioiTinh;
            up.NgaySinh = obj.NgaySinh;
            up.DiaChi = obj.DiaChi;
            up.Sdt = obj.Sdt;
            up.MatKhau = obj.MatKhau;
            up.IdCh = obj.IdCh;
            up.IdCv = obj.IdCv;
            //tempobj.IdGuiBc = obj.IdGuiBc;
            up.TrangThai = obj.TrangThai;
            _context.NhanViens.Update(up);
            _context.SaveChanges();
            return true;
        }
    }
}
