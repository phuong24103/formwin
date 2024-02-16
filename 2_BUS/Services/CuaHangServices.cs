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
    public class CuaHangServices : ICuaHangServices
    {
        ICuaHangRepo _icuahangrepo;
        public CuaHangServices()
        {
            _icuahangrepo = new CuaHangRepo();
        }
        public string Add(CuaHangView obj)
        {
            if (obj == null) return "Thêm thất bại";
            var cuahang = new CuaHang()
            {
                Id = obj.Id,
                Ten = obj.Ten,
                Ma = obj.Ma,
                DiaChi = obj.DiaChi,
                ThanhPho = obj.ThanhPho,
                QuocGia = obj.QuocGia,

            };
            if (_icuahangrepo.Add(cuahang)) return "Thêm thành công";
            return "thêm thất bại";
        }

        public string Delete(Guid obj)
        {
            if (obj == null) return "Xóa thất bại";
            var cuahang = new CuaHang()
            {
                Id = obj,
            };
            if (_icuahangrepo.Delete(cuahang)) return "xóa thành công";
            return "xóa thất bại";
        }

        public List<CuaHangView> GetAll()
        {
            List<CuaHangView> list = new List<CuaHangView>();
            list = (
                from a in _icuahangrepo.GetAll()
                select new CuaHangView()
                {
                    Id = a.Id,
                    Ten = a.Ten,
                    Ma = a.Ma,
                    DiaChi = a.DiaChi,
                    ThanhPho = a.ThanhPho,
                    QuocGia = a.QuocGia,
                }
                ).ToList();
            return list;
                
        }

        public string Update(CuaHangView obj)
        {
            if (obj == null) return "sửa thất bại";
            var cuahang = new CuaHang()
            {
                Id = obj.Id,
                Ten = obj.Ten,
                Ma = obj.Ma,
                DiaChi = obj.DiaChi,
                ThanhPho = obj.ThanhPho,
                QuocGia = obj.QuocGia,
            };
            if (_icuahangrepo.Update(cuahang)) return "sửa thành công";
            return "sửa thất bại";
        }
    }
}
