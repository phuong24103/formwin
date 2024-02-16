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
    public class NhanVienServices : INhanVienServices
   
    {
        INhanVienRepo _nhanvienrp;
        ICuaHangRepo _cuahangrp;
        IChucVuRepo _chucvurp;
        public NhanVienServices()
        {
            _nhanvienrp = new NhanVienRepo();
            _cuahangrp = new CuaHangRepo();
            _chucvurp = new ChucVuRepo();
        }
        public string Add(NhanVienVIew obj)
        {
            if (obj == null) return "Thêm không thành công";
            var nhanvien = new NhanVien()
            {
                Ten = obj.Ten,
                TenDem = obj.TenDem,
                Ho = obj.Ho,
                Ma = obj.Ma,
                DiaChi = obj.DiaChi,
                NgaySinh = obj.NgaySinh,
                GioiTinh = obj.GioiTinh,
                IdCh = obj.IdCh,
                IdCv = obj.IdCv,
                TrangThai = obj.TrangThai,
                Sdt = obj.Sdt,
                MatKhau = obj.MatKhau,
                IdGuiBc = obj.IdGuiBc,

            };
            if (_nhanvienrp.Add(nhanvien)) return "Thêm thành công";
            return "Thêm thất bại";
        }

        public string Delete(Guid obj)
        {
            if (obj == null) return "Xóa không thành công";
            var nhanvien = new NhanVien()
            {
                Id = obj,
            };
            if (_nhanvienrp.Delete(nhanvien)) return "Xóa thành công";
            return "Xóa thất bại";
        }

        public List<NhanVienVIew> GetAll()
        {
            List<NhanVienVIew> lst = new List<NhanVienVIew>();
            lst = (
                from a in _nhanvienrp.GetAll()
                join b in _cuahangrp.GetAll() on a.IdCh equals b.Id
                join c in _chucvurp.GetAll() on a.IdCv equals c.Id
                select new NhanVienVIew()
                {
                    Id = a.Id,
                    Ten = a.Ten,
                    TenDem = a.TenDem,
                    Ho = a.Ho,
                    Ma = a.Ma,
                    DiaChi = a.DiaChi,
                    NgaySinh = a.NgaySinh,
                    GioiTinh = a.GioiTinh,
                    IdCh = a.IdCh,
                    IdCv = a.IdCv,
                    TrangThai = a.TrangThai,
                    Sdt = a.Sdt,
                    MatKhau = a.MatKhau,
                    TenCH = b.Ten,
                    TenCV = c.Ten,
                    IdGuiBc = a.IdGuiBc

                }
                ).ToList();
            return lst;
        }

        public string Update(NhanVienVIew obj)
        {
            if (obj == null) return "sửa thất bại";
            var nhanvien = new NhanVien()
            {
                Id = obj.Id,
                Ten = obj.Ten,
                TenDem = obj.TenDem,
                Ho = obj.Ho,
                Ma = obj.Ma,
                DiaChi = obj.DiaChi,
                NgaySinh = obj.NgaySinh,
                GioiTinh = obj.GioiTinh,
                IdCh = obj.IdCh,
                IdCv = obj.IdCv,
                TrangThai = obj.TrangThai,
                Sdt = obj.Sdt,
                MatKhau = obj.MatKhau,
                IdGuiBc = obj.IdGuiBc,
            };
            if (_nhanvienrp.Update(nhanvien)) return "sửa thành công";
            return "Sửa thất bại";
        }
    }
}
