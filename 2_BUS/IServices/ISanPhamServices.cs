using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IServices
{
    public interface ISanPhamServices
    {
        string Add(SanPhamView obj);
        string Update(SanPhamView obj);
        string Delete(Guid obj);

        List<SanPhamView> GetAll();
    }
}
