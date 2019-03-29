using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BUS;
//using System.Text.RegularExpressions;

namespace QuanLyBanHang
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        private void Login()
        {
            string user = txtUserName.Text;
            string pass = txtPassword.Text;
            UsersBUS u = new UsersBUS();
            if (u.Login(user, pass) == true)
            {
                //MessageBox.Show("Login Success");
                this.DialogResult = MessageBox.Show("Đăng nhập thành công");
            }
            else
            {
                //MessageBox.Show("Login Failed");
                string msg = "Thông tin đăng nhập không đúng, bạn có muốn thử lại?";
                DialogResult result = MessageBox.Show(msg, "Login", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Retry)
                {
                    txtUserName.Text = " ";
                    txtPassword.Text = " ";
                    txtUserName.Focus();
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                Login();
            }
        }

    }
}
