using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace QuanLyBanHang
{
    public partial class FrmQLBH : Form
    {
        
        public FrmQLBH()
        {
            InitializeComponent();
        }

        private void FrmQLBH_Load(object sender, EventArgs e)
        {
            this.Show();
            this.Enabled = false;

            FrmLogin frm = new FrmLogin();
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Enabled = true;
                //lblStatus.Text = "Đăng nhập thành công";
            }
            else
            {
                Application.Exit();
            }
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            FrmSanPham frm = new FrmSanPham();
            frm.ShowDialog();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            FrmKhachHang frm = new FrmKhachHang();
            frm.ShowDialog();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            FrmNhanVien frm = new FrmNhanVien();
            frm.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            FrmSignUp frm = new FrmSignUp();
            frm.ShowDialog();
        }
    }
}
