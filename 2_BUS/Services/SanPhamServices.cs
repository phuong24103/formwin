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
    public class SanPhamServices : ISanPhamServices
    {
        ISanPhamRepo _sprepo;
        public SanPhamServices()
        {
            _sprepo = new SanPhamRepo();
        }
        public string Add(SanPhamView obj)
        {
            if (obj == null)
            {
                return "Thêm thất bại";
            }
            else
            {
                SanPham c = new SanPham()
                {
                    Ma = obj.Ma,
                    Ten = obj.Ten
                };
                _sprepo.Add(c);
                return "Thêm thành công";
            }
        }

        public string Delete(Guid obj)
        {
            if (obj == null)
            {
                return "Xóa thất bại";
            }
            else
            {
                SanPham c = new SanPham()
                {
                    Id = obj,

                };
                _sprepo.Delete(c);
                return "Xóa thành công";
            }
        }

        public List<SanPhamView> GetAll()
        {
            List<SanPhamView> c = new List<SanPhamView>
            (
                from a in _sprepo.GetAll()
                select new SanPhamView()
                {
                    Id = a.Id,
                    Ten = a.Ten,
                    Ma = a.Ma
                });
            return c;
        }

        public string Update(SanPhamView obj)
        {
            if (obj == null)
            {
                return "Sửa thất bại";
            }
            else
            {
                SanPham c = new SanPham()
                {
                    Id = obj.Id,
                    Ma = obj.Ma,
                    Ten = obj.Ten
                };
                _sprepo.Update(c);
                return "Sửa thành công";
            }
        }
    }
}
