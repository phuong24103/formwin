using _1_DAL.IRepositories;
using _1_DAL.Models;
using _1_DAL.Repositories;
using _2_BUS.IServices;
using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.Services
{
    public class QlSpCtServices : IQLSPCTServices
    {
        IDongSpRepo _dongsprepo;
        IMauSacRepo _mausacrepo;
        INXSRepo _nsxrepo;
        ISanPhamRepo _sphamrepo;
        IChiTietSpRepo _chiTietSpRepo;
        public QlSpCtServices()
        {
            _dongsprepo = new DongSpRepo();
            _mausacrepo = new MauSacRepo();
            _nsxrepo = new NXSRepo();
            _chiTietSpRepo = new ChiTietSpRepo();
            _sphamrepo = new SanPhamRepo();
        }
        public string Add(ChiTietSpView obj)
        {
            if (obj == null) return "THêm thất bại";
            var chitiet = new ChiTietSp()
            {
                IdSp = obj.IdSp,
                MoTa = obj.MoTa,
                SoLuongTon = obj.SoLuongTon,
                GiaBan = obj.GiaBan,
                GiaNhap = obj.GiaNhap,
                IdDongSp = obj.IdDongSp,
                IdMauSac = obj.IdMauSac,
                IdNsx = obj.IdNsx,
                NamBh = obj.NamBh,
            };
            if (_chiTietSpRepo.Add(chitiet)) return "Thêm thành công";
            return "thêm thất bại";
        }

        public string Delete(Guid obj)
        {
            if (obj == null) return "Xóa thất bại";
            var chitiet = new ChiTietSp()
            {
                Id = obj,
            };
            if (_chiTietSpRepo.Delete(chitiet)) return "Xóa thành công";
            return "xóa thất bại";
        }

        public List<ChiTietSpView> GetAll()
        {
            List<ChiTietSpView> lst = new List<ChiTietSpView>();
            lst = (from a in _chiTietSpRepo.GetAll()
                   join b in _mausacrepo.GetAll() on a.IdMauSac equals b.Id
                   join c in _dongsprepo.GetAll() on a.IdDongSp equals c.Id
                   join d in _nsxrepo.GetAll() on a.IdNsx equals d.Id
                   join e in _sphamrepo.GetAll() on a.IdSp equals e.Id
                   select new ChiTietSpView()
                   {
                       Id = a.Id,
                       IdSp = a.IdSp,
                       MoTa = a.MoTa,
                       SoLuongTon = a.SoLuongTon,
                       GiaBan = a.GiaBan,
                       GiaNhap = a.GiaNhap,
                       IdDongSp = a.IdDongSp,
                       IdMauSac = a.IdMauSac,
                       IdNsx = a.IdNsx,
                       NamBh = a.NamBh,
                       TenMauSac = b.Ten,
                       TenDongSp = c.Ten,
                       TenNsx = d.Ten,
                       TenSp = e.Ten,
                   }
                   ).ToList();
            return lst;
                  
        }

        public string Update(ChiTietSpView obj)
        {
            if (obj == null) return "Sửa không thành công!";
            var ChiTietSp = new ChiTietSp()
            {
                Id = obj.Id,
                IdSp = obj.IdSp,
                MoTa = obj.MoTa,
                SoLuongTon = obj.SoLuongTon,
                GiaBan = obj.GiaBan,
                GiaNhap = obj.GiaNhap,
                IdDongSp = obj.IdDongSp,
                IdMauSac = obj.IdMauSac,
                IdNsx = obj.IdNsx,
                NamBh = obj.NamBh,

            };
            if (_chiTietSpRepo.Update(ChiTietSp)) return "Sửa thành công";
            return "sửa thất bại";
        }
    }
}
