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
    public class MauSacServices : IMauSacServices
    {
        IMauSacRepo _mauSacRepo;
        public MauSacServices()
        {
            _mauSacRepo = new MauSacRepo();
        }
        public string Add(MauSacView obj)
        {
            if (obj == null) return "thêm thất bại";
            var mausac = new MauSac()
            {
                Id = obj.Id,
                Ma = obj.Ma,
                Ten = obj.Ten
            };
            if (_mauSacRepo.Add(mausac)) return "Thêm thành công";
            return "thêm thất bại";
        }

        public string Delete(Guid obj)
        {
            if (obj == null) return "Xóa thất bại";
            var mausac = new MauSac()
            {
                Id = obj,
            };
            if (_mauSacRepo.Delete(mausac)) return "xóa thành công";
            return "xóa thất bại";
        }

        public List<MauSacView> GetAll()
        {
            List<MauSacView> lst = new List<MauSacView>();
            lst = (
                from a in _mauSacRepo.GetAll()
                select new MauSacView()
                {
                    Id = a.Id,
                    Ten = a.Ten,
                    Ma = a.Ma
                }
                ).ToList();
            return lst;
        }

        public string Update(MauSacView obj)
        {
            if (obj == null) return "Sửa không thành coong";
            var mausac = new MauSac()
            {
                Id = obj.Id,
                Ma = obj.Ma,
                Ten = obj.Ten,
            };
            if (_mauSacRepo.Update(mausac)) return "sửa thành công";
            return "sửa thất bại";  
        }
    }
}
