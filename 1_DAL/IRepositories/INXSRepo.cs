using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IRepositories
{
    public interface INXSRepo
    {
        bool Add(Nsx obj);
        bool Update(Nsx obj);
        bool Delete(Nsx obj);
        List<Nsx> GetAll();
    }
}
