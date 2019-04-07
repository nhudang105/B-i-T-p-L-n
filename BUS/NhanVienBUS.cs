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
    public class NhanVienBUS
    {
        NhanVienDAO NVDAO = new NhanVienDAO();
        public List<NhanVien> LoadNhanVien()
        {
            return NVDAO.LoadNhanVien();
        }

        public int Add(NhanVien em)
        {
            return NVDAO.Add(em);
        }

        public int Delete(string id)
        {
            return NVDAO.Delete(id);
        }

        public int Update(NhanVien nv)
        {
            return NVDAO.Update(nv);
        }

        public NhanVien GetById(string id)
        {
            return NVDAO.GetById(id);
        }
    }
}
