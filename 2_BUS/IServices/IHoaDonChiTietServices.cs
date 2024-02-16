﻿using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IServices
{
    public interface IHoaDonChiTietServices
    {
        string Add(HoaDonChiTietView obj);
        string Update(HoaDonChiTietView obj);
        string Delete(Guid obj);

        List<HoaDonChiTietView> GetAll();
    }
}
