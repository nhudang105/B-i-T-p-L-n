using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

 
namespace DAO
{
    public class UsersDAO : DataProvider
    {
        public List<Users> LoadUsers()
        {
            Connect();
            string sql = "SELECT * FROM Users";

            SqlDataReader dr = MyExecuteReader(sql);
            string name, pass;
            List<Users> list = new List<Users>();
            while (dr.Read())
            {
                //id = dr[0].ToString();
                name = dr[0].ToString();
                pass = dr[1].ToString();
                //unit = dr[2].ToString();
                //unitprice = dr[3].ToString();

                Users u = new Users(name, pass);
                list.Add(u);
            }
            dr.Close();
            DisConnect();
            return list;
        }

        public bool Login(string user, string pass)
        {

            //if (!String.IsNullOrEmpty(user))
            string sql = "SELECT COUNT (UserName) FROM Users WHERE UserName = '" + user.Replace("'", "") + "' And Password = '" + pass.Replace("'", "") + "'";
            int NumberOfRows = MyExecuteScalar(sql);

            if (NumberOfRows > 0)
                return true;
            else
                return false;
        }

        public int Add(Users u)
        {
            string sql = "INSERT INTO Users (UserName, Password) values ('" + u.UserName + "','" + u.Password + "')";

            int NumberOfRows = MyExecuteNonQuery(sql);
            if (NumberOfRows > 0) // nếu thêm thành công trả vè 1 số dương
                return NumberOfRows;
            else
                return -1;
        }
    
    }
}
