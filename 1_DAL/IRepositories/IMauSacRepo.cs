using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IRepositories
{
    public interface IMauSacRepo
    {
        bool Add(MauSac obj);
        bool Update(MauSac obj);
        bool Delete(MauSac obj);
        List<MauSac> GetAll();
    }
}
