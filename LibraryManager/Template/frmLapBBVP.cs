﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManager.BUS;
using LibraryManager.DTO;
namespace LibraryManager.Template
{
    public partial class frmLapBBVP : UserControl
    {
        BienbanVP_BUS bb = new BienbanVP_BUS();
        string MaNV;
        string maVP = "";
        public frmLapBBVP(string manv)
        {
            InitializeComponent();
        }
        private void AutoTaoMaVP()
        {
            string index = (bb.Get_slVP() + 1).ToString();
            maVP = "VP000000";
            maVP = maVP.Substring(0, 8 - index.Length) + index;
            txtMaVP.Text = maVP;

        }
        private void frmLapBBVP_Load(object sender, EventArgs e)
        {
            txtMaNv.Text = MaNV;

            cmbMaDg.DataSource = bb.getMadg();
            cmbMaDg.DisplayMember = "madocgia";
            cmbMaDg.ValueMember = "madocgia";
            
            AutoTaoMaVP();

        }

        private void btnVP_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvSVP.Rows.Count-1; i++)
            {
                if (cmbMasach.Text.Trim() == dgvSVP.Rows[i].Cells[0].Value.ToString().Trim())
                {
                    MessageBox.Show("Mã sách đã tồn tại vi phạm");
                    return;
                }
            }
            dgvSVP.Rows.Add(cmbMasach.Text, bb.get_tensach(cmbMasach.Text),cmbLydo.Text,txtTienphat.Text, "Bỏ");
        }
        private void dgvSVP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == 4)
            {

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xóa sách này ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    dgvSVP.Rows.RemoveAt(e.RowIndex);
                }

            }
        }
        private void cmbMasach_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenSach.Text = bb.get_tensach(cmbMasach.Text.Trim());
        }

        private void cmbMaDg_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenDg.Text = bb.Get_tendg(cmbMaDg.Text);
            cmbMasach.DataSource = bb.getMasach(cmbMaDg.Text);
            cmbMasach.ValueMember = "Masach";
            cmbMasach.DisplayMember = "Masach";

        }

        private void txtMaNv_TextChanged(object sender, EventArgs e)
        {
            txtTenNV.Text = bb.Get_tennv(txtMaNv.Text);
        }

        private void btnLapBB_Click(object sender, EventArgs e)
        {
            int tienphat = 0;
            string lydo = "";
            BienBanViPham bbvp = new BienBanViPham();
            bbvp.MaDocGia = cmbMaDg.Text;
            bbvp.MaNhanVien = txtMaNv.Text;
            bbvp.MaViPham = txtMaVP.Text;
            bbvp.LyDo = cmbLydo.Text;
            for( int i =0; i <dgvSVP.RowCount; i++)
            {
                tienphat += Int32.Parse(dgvSVP.Rows[i].Cells[3].Value.ToString());
                lydo += dgvSVP.Rows[i].Cells[2].Value.ToString();
                if(i!= dgvSVP.RowCount - 1) {
                    lydo += ", ";
                }
            }
            bbvp.LyDo = lydo;
            bbvp.TienPhat = tienphat;
            bbvp.TinhTrangSach = txtTinhtrang.Text;

            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn lập biên bản này không?", "Hỏi đáp?", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {
                bb.insertBB(bbvp);

                for (int i = 0; i < dgvSVP.Rows.Count; i++)
                {
                    ViPham vp = new ViPham();
                    vp.MaSach = dgvSVP.Rows[i].Cells[0].Value.ToString();
                    vp.MaViPham = txtMaVP.Text;

                    bb.Them_vp(vp);
                }
            }
        }

        private void cmbMasach_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            txtTenSach.Text = bb.get_tensach(cmbMasach.Text.Trim());
            cmbLydo_SelectedIndexChanged_1(sender, e);
        }
      
        private void cmbLydo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbLydo.Text == "trả sách trễ hạn")
            {
                if (bb.Songaytre(cmbMasach.Text) < 0)
                {
                    MessageBox.Show("Cuốn sách này chưa đến hạn trả. Vui lòng chọn lý do khác!");
                }
                else
                {
                    long tienphat = bb.Songaytre(cmbMasach.Text) * 2000;// phạt trễ hạn 2000/ngày
                    txtTienphat.Text = tienphat.ToString();
                }
            }
            if (cmbLydo.Text == "làm hỏng sách")
            {
                
                txtTienphat.Text = (bb.TienPhat(cmbMasach.Text) * 0.2).ToString();
            }
            else if (cmbLydo.Text == "làm mất sách")
                //{
                txtTienphat.Text = (bb.TienPhat(cmbMasach.Text) * 1.5).ToString();
        }

        private void dgvSVP_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xóa sách này ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    dgvSVP.Rows.RemoveAt(e.RowIndex);
                }

            }
        }
    }
    
}