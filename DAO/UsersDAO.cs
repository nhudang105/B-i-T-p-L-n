using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class UsersDAO : DataProvider
    {
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
    }
}
