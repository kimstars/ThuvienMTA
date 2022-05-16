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
    class CuonSach_BUS
    {
        CuonSach_DAO sachDao = new CuonSach_DAO();
        public DataTable LoadMaSach()
        {
            return sachDao.GetMaSach();
        }

        public void ThemThongtinNhap(CuonSach cs, PhieuNhap pn)
        {
            sachDao.InsertCuonSach(cs,pn);
        }

        public bool CheckMaSach(string ma)
        {
            if (sachDao.GetCheckMaSach(ma) != 0) return true;
            else return false;
        }
    }
}
