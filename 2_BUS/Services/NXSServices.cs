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

    public class NXSServices : INXSServices
    {
        INXSRepo _repo;
        public NXSServices()
        {
            _repo = new NXSRepo();
        }
        public string Add(NXSView obj)
        {
            if (obj == null) return "THêm không thành công";
            var nxs = new Nsx() {
                Ma = obj.Ma,
                Ten = obj.Ten,
            };
            if (_repo.Add(nxs)) return "THêm thành công";
            return "THêm thaasat bại";
        }

        public string Delete(Guid obj)
        {
            if (obj == null) return "Xóa không thành công";
            var nxs = new Nsx()
            {
                Id = obj,
            };
            if (_repo.Delete(nxs)) return "Xóa thành công";
            return "Xóa thất bại";
        }

        public List<NXSView> GetAll()
        {
            List<NXSView> lst = new List<NXSView>();
            lst = (
                from a in _repo.GetAll()
                select new NXSView()
                {
                    Id = a.Id,
                    Ma = a.Ma,
                    Ten = a.Ten,
                }
                ).ToList();
            return lst;
        }

        public string Update(NXSView obj)
        {
            if (obj == null) return "Sửa không thành công";
            var nsx = new Nsx()
            {
                Ma = obj.Ma,
                Ten = obj.Ten,
            };
            if (_repo.Update(nsx)) return "Sửa thành công";
            return "Sửa thất bại";
        }
    }
}
