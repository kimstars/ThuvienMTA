﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace connect.Template
{
    public partial class QLInfoDocgia : UserControl
    {
        public QLInfoDocgia()
        {
            InitializeComponent();
        }

        private bool CheckPassword(string passwd)
        {

            if (passwd.Length < 6)
            {
                lbMsg.Text = "Mật khẩu tối thiếu là 6 kí tự.";
                return false;
            }
            if (passwd.Contains(" "))
            {
                lbMsg.Text = "Mật khẩu không chứa khoảng trắng.";
                return false;
            }


            return true;
        }

        private string HashPass(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }


        public string GenerateMa(string type)
        {
            string temp = type + "000000";
            return temp;
        }
        private bool validateAll(ref string MaDocGia, string HoTen, string gender, string DiaChi, string sdt, string soCMND, string username, string password)
        {
            if (string.IsNullOrEmpty(HoTen))
            {
                MessageBox.Show(
                "Vui lòng nhập họ và tên",
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return false;

            }
            else if (int.Parse(DateTime.UtcNow.ToString("yyyy")) - birthdayPicker.Value.Year < 15)
            {
                MessageBox.Show(
                "Vui lòng chọn ngày sinh chính xác!",
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return false;

            }
            else if (string.IsNullOrEmpty(DiaChi))
            {
                MessageBox.Show(
                "Vui lòng nhập địa chỉ của bạn!",
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return false;

            }
            else if (string.IsNullOrEmpty(sdt) || sdt.Length > 10)
            {
                MessageBox.Show(
                "Vui lòng nhập chính xác số điện thoại của bạn!",
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return false;

            }
            else if (string.IsNullOrEmpty(soCMND))
            {
                MessageBox.Show(
                "Vui lòng nhập số cmnd của bạn!",
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return false;

            }
            else if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show(
                "Vui lòng nhập tên đăng nhập !",
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return false;

            }
            else if (!CheckPassword(password))
            {
                
                return false;

            }
            else
            {
                return true;
            }
        }

        private void sendData()
        {
            
        }

        private void btnAddInfo_Click(object sender, EventArgs e)
        {
            string MaDocGia = txtMaDG.Text;
            string HoTen = txtHoten.Text;
            string NgaySinh = birthdayPicker.Text;
            string gender = radioGender.Text;
            string DiaChi = txtDiachi.Text;
            string sdt = txtSDT.Text;
            string soCMND = txtCMND.Text;
            string ngayDK = ngayDKPicker.Text;
            string username = txtUsername.Text;
            string password = HashPass(txtPassword.Text);
            if (validateAll(ref MaDocGia, HoTen, gender, DiaChi, sdt, soCMND, username, password))
            {
                ListViewItem lvi = new ListViewItem(MaDocGia);
                lvi.SubItems.Add(HoTen);
                lvi.SubItems.Add(NgaySinh);
                lvi.SubItems.Add(gender);
                lvi.SubItems.Add(DiaChi);
                lvi.SubItems.Add(sdt);
                lvi.SubItems.Add(soCMND);
                lvi.SubItems.Add(ngayDK);
                lvi.SubItems.Add(username);
                lvi.SubItems.Add(password);

                listViewInfo.Items.Add(lvi);

                txtMaDG.Text = "";
                txtHoten.Text = "";
                birthdayPicker.Text = "";
                radioGender.Text = "";
                txtDiachi.Text = "";
                txtSDT.Text = "";
                txtCMND.Text = "";
                ngayDKPicker.Text = "";
                txtUsername.Text = "";
                txtPassword.Text = "";

                MessageBox.Show(
                "Nhập thông tin thành công !!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }

            btnDeleteInfo.Visible = false;
            btnEditInfo.Visible = false;

        }

        private ListViewItem item;

        private void listViewInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewInfo.SelectedItems.Count > 0)
            {
                item = listViewInfo.SelectedItems[0];

                txtMaDG.Text = item.SubItems[0].Text;
                txtHoten.Text = item.SubItems[1].Text;
                birthdayPicker.Text = item.SubItems[2].Text;
                radioGender.Text = item.SubItems[3].Text;
                txtDiachi.Text = item.SubItems[4].Text;
                txtSDT.Text = item.SubItems[5].Text;
                txtCMND.Text = item.SubItems[6].Text;
                dateReg.Text = item.SubItems[7].Text;
                txtUsername.Text = item.SubItems[8].Text;
                txtPassword.Text = item.SubItems[9].Text;
            }
            btnEditInfo.Visible = true;
            btnDeleteInfo.Visible = true;
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            string MaDocGia = txtMaDG.Text;
            string HoTen = txtHoten.Text;
            string NgaySinh = birthdayPicker.Text;
            string gender = radioGender.Text;
            string DiaChi = txtDiachi.Text;
            string sdt = txtSDT.Text;
            string soCMND = txtCMND.Text;
            string ngayDK = ngayDKPicker.Text;
            string username = txtUsername.Text;
            string password = HashPass(txtPassword.Text);
            if (validateAll(ref MaDocGia, HoTen, gender, DiaChi, sdt, soCMND, username, password))
            {
                item.SubItems[0].Text = HoTen;
                item.SubItems[0].Text = NgaySinh;
                item.SubItems[0].Text = gender;
                item.SubItems[0].Text = DiaChi;
                item.SubItems[0].Text = sdt;
                item.SubItems[0].Text = soCMND;
                item.SubItems[0].Text = ngayDK;
                item.SubItems[0].Text = username;
                item.SubItems[0].Text = password;


                txtMaDG.Text = "";
                txtHoten.Text = "";
                birthdayPicker.Text = "";
                radioGender.Text = "";
                txtDiachi.Text = "";
                txtSDT.Text = "";
                txtCMND.Text = "";
                ngayDKPicker.Text = "";
                txtUsername.Text = "";
                txtPassword.Text = "";

                MessageBox.Show(
                "Nhập thông tin thành công !!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }

        }

        private void btnDeleteInfo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thông báo", "Bạn có chắc chắn xóa dòng dữ liệu này không ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                item.Remove();
        }
    }
}
