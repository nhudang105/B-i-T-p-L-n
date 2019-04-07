using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Fax { get; set; }

        public KhachHang(string id, string name, string address, string phonenumber, string fax)
        {
            MaKH = id;
            TenKH = name;
            DiaChi = address;
            DienThoai = phonenumber;
            Fax = fax;
        }

        public KhachHang()
        {
            MaKH = "";
            TenKH = "";
            DiaChi = "";
            DienThoai = "";
            Fax = "";
        }
    }
}
