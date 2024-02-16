using _1_DAL.IRepositories;
using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Repositories
{
    public class ChucVuRepo : IChucVuRepo
    {
        FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context _context;
        public ChucVuRepo()
        {
            _context = new FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context();
        }
        public bool Add(ChucVu obj)
        {
            if(obj == null) return false;
            _context.ChucVus.Add(obj);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(ChucVu obj)
        {
            var xoa = _context.ChucVus.FirstOrDefault(p => p.Id == obj.Id);
            _context.Remove(xoa);
            _context.SaveChanges();
            return true;
        }

        public List<ChucVu> GetAll()
        {
            return _context.ChucVus.ToList();
        }

        public bool Update(ChucVu obj)
        {
            if (obj == null) return false;
            var up = _context.ChucVus.FirstOrDefault(p => p.Id == obj.Id);
            up.Ma = obj.Ma;
            up.Ten = obj.Ten;
            _context.Update(up);
            _context.SaveChanges();
            return true;
        }
    }
}
