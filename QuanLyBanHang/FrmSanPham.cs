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
    public partial class FrmSanPham : Form
    {
        SanPhamBUS SPBUS = new SanPhamBUS();
        public FrmSanPham()
        {
            InitializeComponent();
        }

        private void FrmSanPham_Load(object sender, EventArgs e)
        {
            List<SanPham> list = SPBUS.LoadSanPham();
            dgvSanPham.DataSource = list;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id, name, unit, unitprice;
            id = txtMaSP.Text;
            name = txtTenSP.Text;
            unit = txtDvt.Text;
            unitprice = txtDonGia.Text;
            if (string.IsNullOrEmpty(id))// Nếu id rỗng 
            {
                MessageBox.Show("Chưa nhập Mã sản phẩm");
            }
            else if (string.IsNullOrEmpty(name))// Nếu name rỗng 
            {
                MessageBox.Show("Chưa nhập Tên sản phẩm");
            }
            else if(string.IsNullOrEmpty(unit))// Nếu unit rỗng 
            {
                MessageBox.Show("Chưa nhập Đơn vị tính");
            }
            else if(string.IsNullOrEmpty(unitprice))// Nếu unitprice rỗng 
            {
                MessageBox.Show("Chưa nhập Đơn giá");
            }
            else
            {
                SanPham p = new SanPham(id, name, unit, unitprice);

                int NumberOfRows = SPBUS.Add(p);
                if (NumberOfRows > 0)
                {
                    List<SanPham> list = SPBUS.LoadSanPham();
                    dgvSanPham.DataSource = list;
                    MessageBox.Show("Successfully Added " + NumberOfRows + " Product");
                }
                else
                    MessageBox.Show("Add Failed");
            }
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            if (dgvSanPham.Columns[col] is DataGridViewButtonColumn && dgvSanPham.Columns[col].Name == "CotXoa")
            {
                int row = e.RowIndex;
                string id = dgvSanPham.Rows[row].Cells["CotCanLay"].Value.ToString();
                int NumberOfRows = SPBUS.Delete(id);
                if (NumberOfRows > 0)
                {
                    List<SanPham> list = SPBUS.LoadSanPham();
                    dgvSanPham.DataSource = list;
                    MessageBox.Show("Successfully deleted " + NumberOfRows + " Product");
                }
                else
                    MessageBox.Show("Delete Failed");
            }
        }
    }
}
