﻿using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LibraryManager
{
    public partial class frmNhanvien : Form
    {
        public frmNhanvien()
        {
            InitializeComponent();
        }

        
        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        bool sidebarExpand = true; // menubar
        bool QLSachExpand = true;
        bool QLSachNhapExpand = true;
        bool QLDocgiaExpand = true;
        bool XLMuonTraExpand = true;
        bool XLViPhamExpand = true;
        bool CaiDatExpand = true;



        #region ManagerBar
        private static void opencloseBarDoc(ref Panel thisPanel, ref bool thisExpand, ref Timer thisTick)
        {
            if (thisExpand)
            {
                thisPanel.Height -= 100;
                if (thisPanel.Height == thisPanel.MinimumSize.Height)
                {
                    thisExpand = false;
                    thisTick.Stop();
                }
            }
            else
            {
                thisPanel.Height += 100;
                if (thisPanel.Height == thisPanel.MaximumSize.Height)
                {
                    thisExpand = true;
                    thisTick.Stop();
                }
            }
        }
        private void opencloseBarNgang(ref Panel thisPanel,ref bool thisExpand, ref Timer thisTick)
        {
            if (thisExpand) // thu vao
            {

                PanelMenuBar.Width -= 100;
                if (PanelMenuBar.Width == PanelMenuBar.MinimumSize.Width)
                {
                    thisExpand = false;
                    thisTick.Stop();
                }
               

                foreach (var btn in thisPanel.Controls.OfType<Guna2Button>())
                {
                    btn.Text = "";
                    btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
                    btn.Padding = new Padding(0);
                }
                thisPanel.AutoScroll = false;

            }
            else // mo ra
            {
                PanelMenuBar.Width += 100;
                if (PanelMenuBar.Width == PanelMenuBar.MaximumSize.Width)
                {
                    thisExpand = true;
                    thisTick.Stop();

                }
                
                foreach (Guna2Button btn in thisPanel.Controls.OfType<Guna2Button>())
                {
                    btn.Text = btn.Tag.ToString();
                    btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
                    btn.Padding = new Padding(10, 0, 0, 0);
                }
                thisPanel.AutoScroll = true;

            }
        }


        #endregion



        private void sidebarTickTime_Tick(object sender, EventArgs e)
        {
            opencloseBarNgang(ref PanelMenuBar, ref sidebarExpand, ref sidebarTickTime);
        }

        #region tick doc
        private void QuanLyTickTime_Tick(object sender, EventArgs e)
        {
            opencloseBarDoc(ref PanelQLsach, ref QLSachExpand, ref QuanLyTickTime);
        }

        private void QLSachNhaptick_Tick(object sender, EventArgs e)
        {
            opencloseBarDoc(ref panelQLSachNhap, ref QLSachNhapExpand, ref QLSachNhaptick);
        }

        private void XLMuonTratick_Tick(object sender, EventArgs e)
        {
            opencloseBarDoc(ref panelXLMuontra, ref XLMuonTraExpand, ref XLMuonTratick);
        }

        private void QLDGtick_Tick(object sender, EventArgs e)
        {
            opencloseBarDoc(ref panelQLDocGia, ref QLDocgiaExpand, ref QLDGtick);

        }

        private void XLViPhamTick_Tick(object sender, EventArgs e)
        {
            opencloseBarDoc(ref panelXLViPham, ref XLViPhamExpand, ref XLViPhamTick);

        }

        private void CaiDatTick_Tick(object sender, EventArgs e)
        {
            opencloseBarDoc(ref panelSetting, ref CaiDatExpand, ref CaiDatTick);

        }




        #endregion
        private void CloseDoc()
        {
            if (QLSachExpand) { QuanLyTickTime.Start(); }
            if (QLSachNhapExpand) { QLSachNhaptick.Start(); }
            if (XLMuonTraExpand) { XLMuonTratick.Start(); }
            if (QLDocgiaExpand) { QLDGtick.Start(); }
            if (XLViPhamExpand) { XLViPhamTick.Start(); }
            if (CaiDatExpand) { CaiDatTick.Start(); }
        }

        private void btnM_QLsachnhap_Click(object sender, EventArgs e)
        {
            CloseDoc();
            QLSachNhaptick.Start();
        }

        private void btnMuonTra_Click(object sender, EventArgs e)
        {
            CloseDoc();
            XLMuonTratick.Start();
        }

        private void btnQLsach_Click_1(object sender, EventArgs e)
        {
            CloseDoc();
            QuanLyTickTime.Start();
        }

        private void btnM_QLDG_Click(object sender, EventArgs e)
        {
            CloseDoc();
            QLDGtick.Start();
        }

        private void btnM_XLViPham_Click(object sender, EventArgs e)
        {
            CloseDoc();
            XLViPhamTick.Start();
        }

        private void btnM_Caidat_Click(object sender, EventArgs e)
        {
            CloseDoc();
            CaiDatTick.Start();
        }

        private void frmNhanvien_Load(object sender, EventArgs e)
        {
            CloseDoc();


        }

        private void imgThuVienMTA_Click(object sender, EventArgs e)
        {
            sidebarTickTime.Start();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            panelShow.Controls.Clear();
            panelShow.Controls.Add(new Template.HomeAdmin());
        }
    }
}
