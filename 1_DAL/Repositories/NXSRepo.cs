using _1_DAL.IRepositories;
using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Repositories
{
    public class NXSRepo : INXSRepo
    {
        FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context _context;
        public NXSRepo()
        {
            _context = new FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context();
        }
        public bool Add(Nsx obj)
        {
            if(obj == null) return false;
            _context.Nsxes.Add(obj);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(Nsx obj)
        {
            if(null == obj) return false;
            var del = _context.Nsxes.FirstOrDefault(p => p.Id == obj.Id);
            _context.Nsxes.Remove(del);
            _context.SaveChanges();
            return true;
        }

        public List<Nsx> GetAll()
        {
            return _context.Nsxes.ToList();
        }

        public bool Update(Nsx obj)
        {
            if (obj == null) return false;
            var up = _context.Nsxes.FirstOrDefault(p => p.Id == obj.Id);
            up.Ma = obj.Ma;
            up.Ten = obj.Ten;
            _context.Nsxes.Update(up);
            _context.SaveChanges();
            return true;
        }
    }
}
