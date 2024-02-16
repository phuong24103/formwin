using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IRepositories
{
    public interface ISanPhamRepo
    {
        bool Add(SanPham obj);
        bool Update(SanPham obj);
        bool Delete(SanPham obj);
        List<SanPham> GetAll();
    }
}
