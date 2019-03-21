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
    public class SanPhamBUS
    {
        SanPhamDAO SPDAO = new SanPhamDAO();
        public List<SanPham> LoadSanPham()
        {
            return SPDAO.LoadSanPham();
        }

        public int Add(SanPham p)
        {
            return SPDAO.Add(p);
        }

        public int Delete(string id)
        {
            return SPDAO.Delete(id);
        }
    }
}
