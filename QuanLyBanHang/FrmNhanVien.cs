﻿using System;
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
    public partial class FrmNhanVien : Form
    {
        NhanVienBUS NVBUS = new NhanVienBUS();
        public FrmNhanVien()
        {
            InitializeComponent();
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            List<NhanVien> list = NVBUS.LoadNhanVien();
            dgvNhanVien.DataSource = list;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id, ho, name, address, phone;
            id = txtMa.Text;
            ho = txtHo.Text;
            name = txtTen.Text;
            address = txtDiaChi.Text;
            phone = txtDt.Text;
            NhanVien em = new NhanVien(id, ho, name, address, phone);

            int NumberOfRows = NVBUS.Add(em);;
            if (NumberOfRows > 0)
            {
                List<NhanVien> list = NVBUS.LoadNhanVien();
                dgvNhanVien.DataSource = list;
                MessageBox.Show("Thêm " + NumberOfRows + " nhân viên thành công" );
            }
            else
                MessageBox.Show("Thêm thất bại");
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            if (dgvNhanVien.Columns[col] is DataGridViewButtonColumn && dgvNhanVien.Columns[col].Name == "CotXoa")
            {
                int row = e.RowIndex;
                string id = dgvNhanVien.Rows[row].Cells["CotCanLay"].Value.ToString();
                int NumberOfRows = NVBUS.Delete(id);
                if (NumberOfRows > 0)
                {
                    List<NhanVien> list = NVBUS.LoadNhanVien();
                    dgvNhanVien.DataSource = list;
                    MessageBox.Show("Xóa " + NumberOfRows + " nhân viên thành công");
                }
                else
                    MessageBox.Show("Xóa thất bại");
            }
            else if (dgvNhanVien.Columns[col] is DataGridViewButtonColumn && dgvNhanVien.Columns[col].Name == "cotSua")
            {
                int row = e.RowIndex;
                string id = dgvNhanVien.Rows[row].Cells["CotCanLay"].Value.ToString();
                NhanVien nv = NVBUS.GetById(id);
                nv.HoNV = txtHo.Text;
                nv.Ten = txtTen.Text;
                nv.Diachi = txtDiaChi.Text;
                nv.Dienthoai = txtDt.Text;
                
                int number = NVBUS.Update(nv);

                List<NhanVien> list = NVBUS.LoadNhanVien();
                dgvNhanVien.DataSource = list;
            }
        }
    }
}
