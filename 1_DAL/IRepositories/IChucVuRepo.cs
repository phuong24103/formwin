﻿using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IRepositories
{
    public interface IChucVuRepo
    {
        bool Add(ChucVu obj);
        bool Update(ChucVu obj);
        bool Delete(ChucVu obj);
        List<ChucVu> GetAll();
    }
}
