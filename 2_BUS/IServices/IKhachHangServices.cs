using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IServices
{
    public interface IKhachHangServices
    {
        string Add(KhachHangView obj);
        string Update(KhachHangView obj);
        string Delete(Guid obj);

        List<KhachHangView> GetAll();
    }
}
