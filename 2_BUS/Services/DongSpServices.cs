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
    public class DongSpServices : IDongSpServices
    {
        IDongSpRepo _repo;
        public DongSpServices()
        {
            _repo = new DongSpRepo();
        }
        public string Add(DongSpView obj)
        {
            if (obj == null) return "thêm sản phẩm không thành công";
            var dongsp = new DongSp()
            {
                Id = obj.Id,
                Ma = obj.Ma,
                Ten = obj.Ten
            };
            if (_repo.Add(dongsp)) return "thêm thành công";
            return "thêm thất bại";

        }

        public string Delete(Guid obj)
        {
            if (obj == null) return "xóa thất bại";
            var xoasp = new DongSp() { Id = obj };
            if (_repo.Delete(xoasp)) return "Xóa thành công";
            return "xóa thaaaaaaat bại";

        }

        public List<DongSpView> GetAll()
        {
            List<DongSpView> spview = new List<DongSpView>();
            spview = (
                from a in _repo.GetAll()
                select new DongSpView
                {
                    Id = a.Id,
                    Ten = a.Ten,
                    Ma = a.Ma
                }                
               ).ToList();
            return spview;
        }

        public string Update(DongSpView obj)
        {
            if (obj == null) return "sửa không thành công";
            var dongsp = new DongSp()
            {
                Id = obj.Id,
                Ten = obj.Ten,
                Ma = obj.Ma
            };
            if (_repo.Update(dongsp)) return "sửa thành công";
            return "sửa thất bại";
        }
    }
}
