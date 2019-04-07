using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HoNV { get; set; }
        public string Ten { get; set; }
        public string Diachi { get; set; }
        public string Dienthoai { get; set; }

        public NhanVien(string id, string ho, string name, string address, string phone)
        {
            MaNV = id;
            HoNV = ho;
            Ten = name;
            Diachi = address;
            Dienthoai = phone;
        }

        public NhanVien()
        {
            MaNV = "";
            HoNV = "";
            Ten = "";
            Diachi = "";
            Dienthoai = "";
        }
    }
}
