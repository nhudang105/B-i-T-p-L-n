using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class NhanVienDAO : DataProvider
    {
        public List<NhanVien> LoadNhanVien()
        {
            Connect();
            string sql = "SELECT * FROM NhanVien";

            SqlDataReader dr = MyExecuteReader(sql);
            string id, ho, name, address, phone;
            List<NhanVien> list = new List<NhanVien>();
            while (dr.Read())
            {
                id = dr[0].ToString();
                ho = dr[1].ToString();
                name = dr[2].ToString();
                address = dr[3].ToString();
                phone = dr[4].ToString();

                NhanVien em = new NhanVien(id, ho, name, address, phone);
                list.Add(em);
            }
            dr.Close();
            DisConnect();
            return list;
        }

        public int Add(NhanVien em)
        {
            string sql = "INSERT INTO Nhanvien (MaNV, HoNV, Ten, Diachi, Dienthoai) values ('" + em.MaNV + "','" + em.HoNV + "','" + em.Ten + "','" + em.Diachi + "','" + em.Dienthoai + "')";

            int NumberOfRows = MyExecuteNonQuery(sql);
            if (NumberOfRows > 0)
                return NumberOfRows;
            else
                return -1;
        }

        public int Delete(string id)
        {
            string sql = "DELETE FROM Nhanvien WHERE MaNV = '" + id + "'";
            int NumberOfRows = MyExecuteNonQuery(sql);
            if (NumberOfRows > 0)
                return NumberOfRows;
            else
                return -1;
        }

    }
}
