using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAO;
using DTO;

namespace BUS
{
    public class KhachHangBUS
    {
        KhachHangDAO KHDAO = new KhachHangDAO();
        public List<KhachHang> LoadKhachHang()
        {
            return KHDAO.LoadKhachHang();
        }

        public int Add(KhachHang c)
        {
            return KHDAO.Add(c);
        }

        public int Delete(string id)
        {
            return KHDAO.Delete(id);
        }

        public int Update(KhachHang kh)
        {
            return KHDAO.Update(kh);
        }

        public KhachHang GetById(string id)
        {
            return KHDAO.GetById(id);
        }

    }
}
