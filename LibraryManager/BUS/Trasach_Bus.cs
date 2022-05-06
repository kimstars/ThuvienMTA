﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.DAO;
using LibraryManager.DTO;
using System.Data;
namespace LibraryManager.BUS
{
    class Trasach_Bus
    {
        Trasach_DAO ts_Dao = new Trasach_DAO();
        public DataTable Loadls()
        {
            return ts_Dao.load_trasach();
        }
       public DataTable loadtk_dgia(string a)
        {
            return ts_Dao.loadtk_madg(a);
        }
        public DataTable loadtk_masach(string a)
        {
            return ts_Dao.loadtk_masach(a);
        }
        public void update(string a)
        {
            ts_Dao.Update(a);
            
        }
        public DataTable loadtk_datra()
        {
            return ts_Dao.load_datra();
        }
        public DataTable loadtk_chuatra()
        {
            return ts_Dao.load_chuatra();
        }
    }
}
