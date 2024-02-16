using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IServices
{
    public interface INhanVienServices
    {
        string Add(NhanVienVIew obj);
        string Update(NhanVienVIew obj);
        string Delete(Guid obj);

        List<NhanVienVIew> GetAll();
    }
}
