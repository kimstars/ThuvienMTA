﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.DAO;
using System.Data;
namespace LibraryManager.BUS
{
    class BienbanVP_BUS
    {
        BienbanVP_DAO bbvp_dao = new BienbanVP_DAO();
        public string Get_tendg(string a)
        {
            return bbvp_dao.get_ten_dg(a);
        }
        public string Get_tennv(string a)
        {
            return bbvp_dao.get_ten_nv(a);
        }
        public int Get_slVP()
        {
            return int.Parse(bbvp_dao.Get_sl_MaVP());
        }
        public DataTable getManv()
        {
            return bbvp_dao.loadManv();
        }
    }
}
