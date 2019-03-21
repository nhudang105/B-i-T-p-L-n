using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class KhachHangDAO : DataProvider
    {
        public List<KhachHang> LoadKhachHang()
        {
            Connect();
            string sql = "SELECT * FROM KhachHang";

            SqlDataReader dr = MyExecuteReader(sql);
            string id, name, address;
            string phonenumber, fax;
            List<KhachHang> list = new List<KhachHang>();
            while (dr.Read())
            {
                id = dr[0].ToString();
                name = dr[1].ToString();
                address = dr[2].ToString();
                phonenumber = dr[3].ToString();
                fax = dr[4].ToString();

                KhachHang c = new KhachHang(id, name, address, phonenumber, fax);
                list.Add(c);
            }
            dr.Close();
            DisConnect();
            return list;
        }

        public int Add(KhachHang c)
        {
            string sql = "INSERT INTO KhachHang (MaKH, TenKH, DiaChi, DienThoai, Fax) values ('" + c.MaKH + "','" + c.TenKH + "','" + c.DiaChi + "','" + c.DienThoai + "','" + c.Fax + "')";

            int NumberOfRows = MyExecuteNonQuery(sql);
            if (NumberOfRows > 0)
            {
                return NumberOfRows;
            }
            else return -1;
        }

        public int Delete(string id)
        {
            string sql = "DELETE FROM KhachHang WHERE MaKH = '" + id + "'";
            int NumberOfRows = MyExecuteNonQuery(sql);
            if (NumberOfRows > 0)
                return NumberOfRows;
            else
                return -1;
        }
    }

    
}
