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
    public class KhachHangServices : IKhachHangServices
    {
        IKhachHangRepo _khachHangRepo;
        public KhachHangServices()
        {
            _khachHangRepo = new KhachHangRepo();
        }
        public string Add(KhachHangView obj)
        {
            if (obj == null) return "thêm không thành công";
            var kh = new KhachHang()
            {
                Ten = obj.Ten,
                TenDem = obj.TenDem,
                Ho = obj.Ho,
                Ma = obj.Ma,
                DiaChi = obj.DiaChi,
                NgaySinh = obj.NgaySinh,
                ThanhPho = obj.ThanhPho,
                Sdt = obj.Sdt,
                MatKhau = obj.MatKhau,
                QuocGia = obj.QuocGia
            };
            if (_khachHangRepo.Add(kh)) return "Thêm thành công";
            return "thêm thất bại";
        }

        public string Delete(Guid obj)
        {
            if (obj == null) return "xóa thất bại";
            var kh = new KhachHang()
            {
                Id = obj,
            };
            if (_khachHangRepo.Delete(kh)) return "xóa thành công";
            return "xóa thất bại";
        }

        public List<KhachHangView> GetAll()
        {
            List<KhachHangView> lst = new List<KhachHangView>();
            lst = (
                from a in _khachHangRepo.GetAll()
                select new KhachHangView()
                {
                    Id = a.Id,
                    Ten = a.Ten,
                    TenDem = a.TenDem,
                    Ho = a.Ho,
                    Ma = a.Ma,
                    DiaChi = a.DiaChi,
                    NgaySinh = a.NgaySinh,
                    ThanhPho = a.ThanhPho,
                    Sdt = a.Sdt,
                    MatKhau = a.MatKhau,
                    QuocGia = a.QuocGia
                }
                
                ).ToList();
            return lst;
        }


        public string Update(KhachHangView obj)
        {
            if (obj == null) return "sửa thất bại";
            var khachhang = new KhachHang()
            {
                Id = obj.Id,
                Ten = obj.Ten,
                TenDem = obj.TenDem,
                Ho = obj.Ho,
                Ma = obj.Ma,
                DiaChi = obj.DiaChi,
                NgaySinh = obj.NgaySinh,
                ThanhPho = obj.ThanhPho,
                Sdt = obj.Sdt,
                MatKhau = obj.MatKhau,
                QuocGia = obj.QuocGia
            };
            if (_khachHangRepo.Add(khachhang)) return "sửa thành công";
            return "sửa thất bại";
        }
    }
}
