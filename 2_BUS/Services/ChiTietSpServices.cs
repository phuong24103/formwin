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
    public class ChiTietSpServices : IChiTietSpServices
    {
        IChiTietSpRepo _spctrp;
        ISanPhamRepo _sprepo;
        public ChiTietSpServices()
        {
            _spctrp = new ChiTietSpRepo();
            _sprepo = new SanPhamRepo();
        }
        public string Add(Ctsp_view obj)
        {
            if (obj == null)
            {
                return "thêm thất bại";
            }
            else
            {
                ChiTietSp chiTietSp = new ChiTietSp()
                {
                    IdSp = obj.IdSp,
                    MoTa = obj.MoTa,
                    SoLuongTon = obj.SoLuongTon,
                    GiaNhap = obj.GiaNhap,
                    GiaBan = obj.GiaBan,


                };
                _spctrp.Add(chiTietSp);
                return "thêm thành công";
            }
        }

        public string Delete(Guid obj)
        {
            if (obj == null)
            {
                return "xóa thất bại";
            }
            else
            {
                var del = _spctrp.GetAll().FirstOrDefault(p => p.Id == obj);
                _spctrp.Delete(del);
                return "xóa thành công";
            }
        }

        public List<Ctsp_view> GetAll()
        {
            List<Ctsp_view> list = new List<Ctsp_view>(
            
                from a in _spctrp.GetAll()
                join b in _sprepo.GetAll()
                on a.Id equals b.Id
                select new Ctsp_view()
                {
                    Id = a.Id,
                    IdSp = a.IdSp,
                    MoTa = a.MoTa,
                    TenSp = b.Ten,
                    SoLuongTon = a.SoLuongTon,
                    GiaBan = a.GiaBan,
                    GiaNhap = a.GiaNhap,
                    GiaTriTon = a.GiaNhap*a.SoLuongTon,
                    
                }
              
            ).ToList();
            return list;
        }

        public ChiTietSpView GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public string Update(Ctsp_view obj)
        {
           var up = _spctrp.GetAll().FirstOrDefault(p =>p.Id == obj.Id);
            up.IdSp = obj.IdSp;
            up.MoTa = obj.MoTa;
            up.SoLuongTon= obj.SoLuongTon;
            up.GiaBan = obj.GiaBan;
            up.GiaNhap = obj.GiaNhap;
            _spctrp.Update(up);
            return "sửa thành công";
        }
    }
}
