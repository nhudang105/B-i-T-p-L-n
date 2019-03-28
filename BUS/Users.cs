using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class UsersBUS
    {
        UsersDAO uDAO = new UsersDAO();

        public List<Users> LoadUsers()
        {
            return uDAO.LoadUsers();
        }

        public bool Login(string user, string pass)
        {
            return uDAO.Login(user, pass);
        }

        public int Add(Users u)
        {
            return uDAO.Add(u);
        }
    }
}
