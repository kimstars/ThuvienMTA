﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LibraryManager.Template
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void closeYCollapse()
        {
            if (QLNVTickCollapse)
            {
                Open_Y(ref panelQLNV, ref QLNVTickCollapse);
            }
            if (QLSachTickCollapse)
            {
                Open_Y(ref panelQLsach, ref QLSachTickCollapse);
            }
            if (QLSachNhap)
            {
                Open_Y(ref panelQLSachNhap, ref QLSachNhap);
            }
            if (XLMuonTra)
            {
                Open_Y(ref panelXLMuontra, ref XLMuonTra);
            }
            if (XLViPham)
            {
                Open_Y(ref panelXLViPham, ref XLViPham);

            }

        }

        bool sidebarExpand = false;
        bool QLSachTickCollapse = true;
        bool QLNVTickCollapse = true;
        bool QLDGTickCollapse = true;


        private void sidebartick_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand) // thu vao
            {
                closeYCollapse();
                PanelMenuBar.Width -= 100;
                if (PanelMenuBar.Width == PanelMenuBar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebartick.Stop();

                }
                PanelMenuBar.AutoScroll = false;

                pictureAvt.Size = new Size(40, 40);


            }
            else // mo ra
            {
                PanelMenuBar.Width += 100;
                if (PanelMenuBar.Width == PanelMenuBar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebartick.Stop();
                }
                PanelMenuBar.AutoScroll = true;

                pictureAvt.Size = new Size(60, 60);

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            sidebartick.Start();
        }

        private void FormAdmin_Load_1(object sender, EventArgs e)
        {
            PanelMenuBar.Width = PanelMenuBar.MinimumSize.Width;
            PanelMenuBar.AutoScroll = false;
            closeYCollapse();

        }




        private void Open_Y(ref Panel thisPanel, ref bool thisCollapse)
        {
            if (thisCollapse)
            {

                thisPanel.Height = thisPanel.MinimumSize.Height;
                thisCollapse = false;
            }
            else
            {
                thisPanel.Height = thisPanel.MaximumSize.Height;
                thisCollapse = true;
            }
        }



        private void btnDSNV_Click(object sender, EventArgs e)
        {
            closeYCollapse();

        }



        private void btnThuNghiem_Click(object sender, EventArgs e)
        {
            closeYCollapse();
            //infoDG.Visible = true;


        }

        private void btnOpenQLNV_Click(object sender, EventArgs e)
        {
            Open_Y(ref panelQLNV, ref QLNVTickCollapse);
        }

        private void btnM_QLsach_Click(object sender, EventArgs e)
        {
            Open_Y(ref panelQLsach, ref QLSachTickCollapse);
        }
        bool QLSachNhap = true;
        private void btnM_QLsachnhap_Click(object sender, EventArgs e)
        {
            Open_Y(ref panelQLSachNhap, ref QLSachNhap);
        }
        bool XLMuonTra = true;

        private void btnM_XLMuonTra_Click(object sender, EventArgs e)
        {
            Open_Y(ref panelXLMuontra, ref XLMuonTra);

        }
        bool XLViPham = true;
        private void btnM_XLViPham_Click(object sender, EventArgs e)
        {
            Open_Y(ref panelXLViPham, ref XLViPham);
        }
    }
}
