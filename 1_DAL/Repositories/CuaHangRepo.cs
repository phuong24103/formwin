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
    public class CuaHangRepo : ICuaHangRepo
    {
        FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context _context;
        public CuaHangRepo()
        {
            _context = new FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context();
        }
        public bool Add(CuaHang obj)
        {
            if(obj == null) return false;
            _context.CuaHangs.Add(obj);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(CuaHang obj)
        {
            var del = _context.CuaHangs.FirstOrDefault(p => p.Id == obj.Id);
            _context.Remove(del);
            _context.SaveChanges();
            return true;
        }

        public List<CuaHang> GetAll()
        {
            return _context.CuaHangs.ToList();
        }

        public bool Update(CuaHang obj)
        {
            if (obj == null) return false;
            var up = _context.CuaHangs.FirstOrDefault(p => p.Id == obj.Id);
            up.Ma = obj.Ma;
            up.Ten = obj.Ten;
            up.DiaChi = obj.DiaChi;
            up.ThanhPho = obj.ThanhPho;
            up.QuocGia = obj.QuocGia;
            _context.Update(up);
            _context.SaveChanges();
            return true;
        }
    }
}
