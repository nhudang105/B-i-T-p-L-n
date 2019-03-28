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
using DTO;

namespace QuanLyBanHang
{
    public partial class FrmSignUp : Form
    {
        UsersBUS uBUS = new UsersBUS();
        public FrmSignUp()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string name, pass;
            name = txtUsername.Text;
            pass = txtPassword.Text;
            if (string.IsNullOrEmpty(name))// Nếu username rỗng 
            {
                MessageBox.Show("Chưa nhập Username");
            }
            else if (string.IsNullOrEmpty(pass))// Nếu password rỗng 
            {
                MessageBox.Show("Chưa nhập Password");
            }
            else
            {
                Users u = new Users(name, pass);
                int NumberOfRows = uBUS.Add(u);

                if (NumberOfRows > 0)
                {
                    //List<Users> list = uBUS.LoadUsers();
                    //dgvSanPham.DataSource = list;
                    MessageBox.Show("Đăng ký thành công");

                    this.Close();
                    this.Enabled = false;

                    FrmLogin frm = new FrmLogin();
                    DialogResult result = frm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        this.Enabled = true;
                        //frm.Close();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                else
                    MessageBox.Show("Đăng ký thất bại");
            }
        }
        
    }
}
