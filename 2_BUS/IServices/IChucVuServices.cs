using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IServices
{
    public interface IChucVuServices
    {
        string Add(ChucVuView obj);
        string Update(ChucVuView obj);
        string Delete(Guid obj);

        List<ChucVuView> GetAll();
    }
}
