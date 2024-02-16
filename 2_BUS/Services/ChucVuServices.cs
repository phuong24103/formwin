using _1_DAL.IRepositories;
using _1_DAL.Models;
using _1_DAL.Repositories;
using _2_BUS.IServices;
using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.Services
{
    public class ChucVuServices : IChucVuServices
    {
        IChucVuRepo _Ichucvurepo;

        public ChucVuServices()
        {
            _Ichucvurepo = new ChucVuRepo();

        }

        public string Add(ChucVuView obj)
        {
            if (obj == null)
            
                return "Thêm thất bại";
            
            var chucvu = new ChucVu()
            {
                Ten = obj.Ten,
                Ma = obj.Ma,
            };
            if (_Ichucvurepo.Add(chucvu)) return "Thêm thành công;";
            return "thêm thất bại";


        }

        public string Delete(Guid obj)
        {
            if (obj == null) return "xóa thất bại";
            var chucvu = new ChucVu()
            {
                Id = obj,
            };
            if (_Ichucvurepo.Delete(chucvu)) return "xóa thành công";
            return "xóa thất bại";
        }

        public List<ChucVuView> GetAll()
        {
            List<ChucVuView> list = new List<ChucVuView>();
            list = 
                (
                from a in _Ichucvurepo.GetAll()
                select new ChucVuView()
                {
                    Id = a.Id,
                    Ma = a.Ma,
                    Ten = a.Ten,
                }).ToList();
            return list;
        }

        public string Update(ChucVuView obj)
        {
            if (obj == null) return "Sửa không thành công";
            var chucvu = new ChucVu()
            {
                Id = obj.Id,
                Ma = obj.Ma,
                Ten = obj.Ten,
            };
            if (_Ichucvurepo.Update(chucvu)) return " sửa thành công";
            return "sửa không thành công";
        }
    }

    
}
