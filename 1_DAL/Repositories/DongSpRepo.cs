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
    public class DongSpRepo : IDongSpRepo
    {
        FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context _context;
        public DongSpRepo()
        {
            _context = new FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context();
        }
        public bool Add(DongSp obj)
        {
            if(obj == null) return false;
            _context.DongSps.Add(obj);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(DongSp obj)
        {
            if(null == obj) return false;   
            var del = _context.DongSps.FirstOrDefault(p => p.Id == obj.Id);
            _context.Remove(del);
            _context.SaveChanges();
            return true;
        }

        public List<DongSp> GetAll()
        {
            return _context.DongSps.ToList();
        }

        public bool Update(DongSp obj)
        {
           
            if(obj == null) return false;
            var up = _context.DongSps.FirstOrDefault(p => p.Id == obj.Id);
            up.Ma = obj.Ma;
            up.Ten = obj.Ten;
            _context.Update(up);
            _context.SaveChanges();
            return true;
        }
    }
}
