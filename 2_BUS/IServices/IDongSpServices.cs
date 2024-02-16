using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IServices
{
    public interface IDongSpServices
    {
        string Add(DongSpView obj);
        string Update(DongSpView obj);
        string Delete(Guid obj);

        List<DongSpView> GetAll();
    }
}
