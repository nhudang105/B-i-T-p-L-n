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

        private void btnLogin_Click(object sender, EventArgs e)
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
                if (result == DialogResult.Retry )
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

        //private void FrmLogin_Load(object sender, EventArgs e)
        //{
        //    this.Show();
        //    this.Enabled = false;

        //    FrmSignUp frm = new FrmSignUp();
        //    DialogResult result = frm.ShowDialog();
        //    if (result == DialogResult.OK)
        //    {
        //        this.Enabled = true;
        //    }
        //    else
        //    {
        //        Application.Exit();
        //    }
        //}
        //private void Login(string user, string pass)
        //{
        //    // string PASSWORD_PATTERN = "^(?=.*[A-Z])(?=.*[!@#$&*])(?=.*[0 - 9])(?=.*[a - z]).{ 8,}$";

        //    // ^ : bắt đầu chuôi
        //    // $ : kết thúc chuỗi
        //    // (): nhóm các ký tự 
        //    // . : kí tự bất kỳ
        //    // * : số lần lặp bất kỳ
        //    // ?=: cái này hơi căng

        //    string PASSWORD_PATTERN = "^(?=.*[A-Z])" // [A-Z] chứa ký tự in hoa 
        //                            + "(?=.*[!@#$&*])" // [!@#$&*] chứa ký tự đặt biệt
        //                            + "(?=.*[0-9])" // [0-9] chứa ký tự số
        //                            + "(?=.*[a-z])" // [a-z] chứa ký tự in thường
        //                            + ".{8,}$"; // {8,} độ dài từ 8 trở lên

        //    // Match,Regex : xài thư viện System.Text.RegularExpressions
        //    Match match = Regex.Match(pass, PASSWORD_PATTERN);
        //    UsersBUS u = new UsersBUS();
        //    if (match.Success)
        //    {
        //        // Kiểm tra UserName,nếu chưa tồn tại thì cho đăng ký

        //    }
        //    else
        //    {
        //        MessageBox.Show("Password không đúng định dạng");
        //    }
        //}
    }
}
