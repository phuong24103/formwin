using _1_DAL.IRepositories;
using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Repositories
{
    public class ChiTietSpRepo : IChiTietSpRepo
    {
        FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context _context;
        public ChiTietSpRepo()
        {
            _context = new FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context();
        }
        public bool Add(ChiTietSp obj)
        {
            if (obj == null) return false;
            _context.ChiTietSps.Add(obj);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(ChiTietSp obj)
        {
            if(obj == null) return false;
            var xoa = _context.ChiTietSps.FirstOrDefault(x => x.Id == obj.Id);
            _context.ChiTietSps.Remove(xoa);
            return true;
        }

        public List<ChiTietSp> GetAll()
        {
            return _context.ChiTietSps.ToList();
        }

        public bool Update(ChiTietSp obj)
        {
            if (obj == null) return false;
            var up = _context.ChiTietSps.FirstOrDefault(p => p.Id == obj.Id);
            up.IdSp = obj.IdSp;
            up.IdNsx = obj.IdNsx;
            up.IdMauSac = obj.IdMauSac;
            up.IdDongSp = obj.IdDongSp;
            up.NamBh = obj.NamBh;
            up.MoTa = obj.MoTa;
            up.SoLuongTon = obj.SoLuongTon;
            up.GiaNhap = obj.GiaNhap;
            up.GiaBan = obj.GiaBan;
            _context.ChiTietSps.Update(up);
            _context.SaveChanges();
            return true;
            

            
        }
    }
}
