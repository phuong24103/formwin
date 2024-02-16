using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IServices
{
    public interface INXSServices
    {
        string Add(NXSView obj);
        string Update(NXSView obj);
        string Delete(Guid obj);

        List<NXSView> GetAll();
    }
}
