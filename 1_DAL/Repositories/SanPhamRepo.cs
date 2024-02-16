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
    public class SanPhamRepo : ISanPhamRepo
    {
        FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context _context;
        public SanPhamRepo()
        {
            _context = new FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context();
        }
        public bool Add(SanPham obj)
        {
            if(obj == null) return false;
            _context.SanPhams.Add(obj);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(SanPham obj)
        {
            if( obj == null) return false;
            var del = _context.SanPhams.FirstOrDefault(p => obj.Id == obj.Id);
            _context.SanPhams.Remove(del);
            _context.SaveChanges();
            return true;

        }

        public List<SanPham> GetAll()
        {
            return _context.SanPhams.ToList();
        }

        public bool Update(SanPham obj)
        {
            if (obj == null) return false;
            var up = _context.SanPhams.FirstOrDefault(p => obj.Id == obj.Id);
            up.Ma = obj.Ma;
            up.Ten = obj.Ten;
            _context.Update(up);
            _context.SaveChanges();
            return true;
        }
    }
}
