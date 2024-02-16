using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IRepositories
{
    public interface IDongSpRepo
    {
        bool Add(DongSp obj);
        bool Update(DongSp obj);
        bool Delete(DongSp obj);
        List<DongSp> GetAll();
    }
}
