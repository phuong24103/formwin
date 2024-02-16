using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IServices
{
    public interface ICuaHangServices
    {
        string Add(CuaHangView obj);
        string Update(CuaHangView obj);
        string Delete(Guid obj);

        List<CuaHangView> GetAll();
    }
}
