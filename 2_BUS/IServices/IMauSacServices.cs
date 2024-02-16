using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IServices
{
    public interface IMauSacServices
    {
        string Add(MauSacView obj);
        string Update(MauSacView obj);
        string Delete(Guid obj);

        List<MauSacView> GetAll();
    }
}
