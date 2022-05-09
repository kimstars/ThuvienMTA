﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.DAO;
using LibraryManager.DTO;
using System.Data;
using System.Windows.Forms;


namespace LibraryManager.BUS
{
    class PhieuMuon_BUS
    {
        PhieuMuon_DAO pmDao = new PhieuMuon_DAO();
        public DataTable LoadDSPhieumuon()
        {
            return pmDao.Get_DSphieumuon();
        }
        public DataTable LoadDSPhieumuon(DateTime start, DateTime end)
        {
            return pmDao.Get_DSphieumuon(start,end);
        }
        public DataTable LoadDSPhieumuon(string keyword)
        {
            return pmDao.Get_DSphieumuon(keyword);
        }


        public DataTable Load_Thongtinsachmuon(string MaMuonTra)
        {
            return pmDao.GetThongtinSachMuon(MaMuonTra);
        }


        public string GetLastest_MaPhieuMuon()
        {
            return pmDao.GetLastest_MaPhieuMuon();
        }

        public string CreateNext_MaMT() // tạo mã phiếu mượn tự động 
        {
            string current = GetLastest_MaPhieuMuon();

            string inc = System.Text.RegularExpressions.Regex.Match(current, @"\d+\.*\d*").Value;
            string index = (int.Parse(inc)+1).ToString();
  
            string maMuon = "MT000000";
            maMuon = maMuon.Substring(0, maMuon.Length - index.Length) + index;

            return maMuon;
        }


        #region Docgia muon 

        public void DocGiaMuon(PhieuMuonTra pm, List<string> dsMaSach)
        {
            pmDao.InsertPhieuMuonTra(pm, dsMaSach);
        }

        #endregion



    }
}
