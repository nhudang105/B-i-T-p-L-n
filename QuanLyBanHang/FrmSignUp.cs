using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                if (IsDuplicateUser(name) == false)
                {
                    if (IsAcceptPass(pass))
                    {
                        // Kiểm tra UserName,nếu chưa tồn tại thì cho đăng ký
                        // Password hợp lệ mới cho đăng ký
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
                    else
                    {
                        MessageBox.Show("Password không đúng định dạng!");
                    }

                }
                else
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại!");
                }

            }
        }

        private bool IsAcceptPass(string pass)
        {
            // kiểm tra pass
            string PASSWORD_PATTERN = "^(?=.*[A-Z])" // [A-Z] chứa ký tự in hoa 
                               + "(?=.*[!@#$&*])" // [!@#$&*] chứa ký tự đặt biệt
                               + "(?=.*[0-9])" // [0-9] chứa ký tự số
                               + "(?=.*[a-z])" // [a-z] chứa ký tự in thường
                               + ".{8,}$"; // {8,} độ dài từ 8 trở lên

            Match match = Regex.Match(pass, PASSWORD_PATTERN);
            if (match.Success)
                return true;
            return false;
        }

        private bool IsDuplicateUser(string userName)
        {
            var listUser = uBUS.LoadUsers();
            int number = listUser.Where(x => x.UserName == userName).Count();
            if (number > 0)
            {
                return true;
            }
            return false;
        }

    }
}
