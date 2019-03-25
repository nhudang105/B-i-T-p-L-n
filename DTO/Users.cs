using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Users
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public Users (string name, string pass)
        {
            UserName = name;
            Password = pass;
        }
    }
}
