using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IRepositories
{
    public interface IChiTietSpRepo
    {
        bool Add(ChiTietSp obj);
        bool Update(ChiTietSp obj);
        bool Delete(ChiTietSp obj);
        List<ChiTietSp> GetAll();
    }
}
