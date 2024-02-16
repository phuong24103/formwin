using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IServices
{
    public interface IHoaDonServices
    {
        string Add(HoaDonView obj);
        string Update(HoaDonView obj);
        string Delete(Guid obj);

        List<HoaDonView> GetAll();
    }
}
