using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IRepositories
{
    public interface INhanVienRepo
    {
        bool Add(NhanVien obj);
        bool Update(NhanVien obj);
        bool Delete(NhanVien obj);
        List<NhanVien> GetAll();
    }
}
