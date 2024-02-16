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
    public class MauSacRepo : IMauSacRepo
    {
        FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context _context;
        public MauSacRepo()
        {
            _context = new FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context();
        }
        public bool Add(MauSac obj)
        {
            if (obj == null) return false;
            _context.MauSacs.Add(obj);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(MauSac obj)
        {
            if (obj == null) return false;
            var del = _context.MauSacs.FirstOrDefault(p => p.Id == obj.Id);
            _context.MauSacs.Remove(del);
            _context.SaveChanges();
            return true;
        }

        public List<MauSac> GetAll()
        {
            return _context.MauSacs.ToList();
        }

        public bool Update(MauSac obj)
        {
            if (obj == null) return false;
            var up = _context.MauSacs.FirstOrDefault(p => p.Id == obj.Id);
            up.Ma = obj.Ma;
            up.Ten = obj.Ten;
            _context.Update(up);
            _context.SaveChanges();
            return true;
        }
    }
}
