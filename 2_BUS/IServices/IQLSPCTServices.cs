using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IServices
{
    public interface IQLSPCTServices
    {
        string Add(ChiTietSpView obj);
        string Update(ChiTietSpView obj);
        string Delete(Guid obj);


        List<ChiTietSpView> GetAll();
    }
}
