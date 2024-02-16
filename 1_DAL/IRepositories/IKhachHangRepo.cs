using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IRepositories
{
    public interface IKhachHangRepo
    {
        bool Add(KhachHang obj);
        bool Update(KhachHang obj);
        bool Delete(KhachHang obj);
        List<KhachHang> GetAll();
    }
}
