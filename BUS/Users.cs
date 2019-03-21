using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class UsersBUS
    {
        Users u = new Users();

        public bool Login(string user, string pass)
        {
            return u.Login(user, pass);
        }
    }
}
