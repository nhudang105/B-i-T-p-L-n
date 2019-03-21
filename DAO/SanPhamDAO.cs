using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class SanPhamDAO : DataProvider
    {
        public List<SanPham> LoadSanPham()
        {
            Connect();
            string sql = "SELECT * FROM SanPham";

            SqlDataReader dr = MyExecuteReader(sql);
            string id, name, unit, unitprice;
            List<SanPham> list = new List<SanPham>();
            while (dr.Read())
            {
                id = dr[0].ToString();
                name = dr[1].ToString();
                unit = dr[2].ToString();
                unitprice = dr[3].ToString();

                SanPham p = new SanPham(id, name, unit, unitprice);
                list.Add(p);
            }
            dr.Close();
            DisConnect();
            return list;
        }

        public int Add(SanPham p)
        {
            string sql = "INSERT INTO SanPham (MaSP, TenSP, Donvitinh, Dongia) values ('" + p.MaSP + "','" + p.TenSP + "','" + p.Donvitinh + "','" + p.Dongia + "')";

            int NumberOfRows = MyExecuteNonQuery(sql);
            if (NumberOfRows > 0)
                return NumberOfRows;
            else
                return -1;
        }

        public int Delete (string id)
        {
            string sql = "DELETE FROM SanPham WHERE MaSP = '" + id + "'";
            int NumberOfRows = MyExecuteNonQuery(sql);
            if (NumberOfRows > 0)
                return NumberOfRows;
            else
                return -1;
        }
    }
}
