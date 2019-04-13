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
            SanPham p = new SanPham(id, name, unit, unitprice);

            int NumberOfRows = SPBUS.Add(p);
            if (NumberOfRows > 0)
            {
                List<SanPham> list = SPBUS.LoadSanPham();
                dgvSanPham.DataSource = list;
                MessageBox.Show("Thêm " + NumberOfRows + " sản phẩm thành công");
            }
            else
                MessageBox.Show("Thêm thất bại");

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
                    MessageBox.Show("Xóa " + NumberOfRows + " sản phẩm thành công");
                }
                else
                    MessageBox.Show("Xóa thất bại");
            }
            else if (dgvSanPham.Columns[col] is DataGridViewButtonColumn && dgvSanPham.Columns[col].Name == "cotSua")
            {
                int row = e.RowIndex;
                string id = dgvSanPham.Rows[row].Cells["CotCanLay"].Value.ToString();
                SanPham sp = SPBUS.GetById(id);
                //string name, unit, unitprice;
                //id = txtMaSP.Text;
                //name = txtTenSP.Text;
                //unit = txtDvt.Text;
                //unitprice = txtDonGia.Text;
                //SanPham p = new SanPham(id, name, unit, unitprice);
                sp.TenSP = txtTenSP.Text;
                sp.TenSP = txtTenSP.Text;
                sp.Donvitinh = txtDvt.Text;
                sp.Dongia = txtDonGia.Text;
                            
                int number = SPBUS.Update(sp);
                       
                List<SanPham> list = SPBUS.LoadSanPham();
                dgvSanPham.DataSource = list;
            }
        }
    }
}
