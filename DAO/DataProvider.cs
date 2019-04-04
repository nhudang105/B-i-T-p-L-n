using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DataProvider
    {
        public SqlConnection cn;

        public DataProvider()
        {
            string cnStr = "Data Source=.;Initial Catalog=QLBH;Integrated Security=True";
            cn = new SqlConnection(cnStr);
        }

        public void Connect()
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DisConnect()
        {
            if (cn.State == ConnectionState.Open)
                cn.Close();
        }

        public int MyExecuteScalar(string sql)
        {
            Connect();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;

            int NumberOfRows;
            NumberOfRows = (int)cmd.ExecuteScalar();

            DisConnect();

            return NumberOfRows;
        }

        public SqlDataReader MyExecuteReader(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;

            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public int MyExecuteNonQuery(string sql)
        {
            Connect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;

            int NumberOfRows = cmd.ExecuteNonQuery();
            DisConnect();
            return NumberOfRows;
        }



    }
}
