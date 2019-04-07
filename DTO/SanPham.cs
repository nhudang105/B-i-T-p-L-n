using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPham
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string Donvitinh { get; set; }
        public string Dongia { get; set; }

        public SanPham(string id, string name, string unit, string unitprice)
        {
            MaSP = id;
            TenSP = name;
            Donvitinh = unit;
            Dongia = unitprice;
        }

        public SanPham()
        {
            MaSP = "";
            TenSP = "";
            Donvitinh = "";
            Dongia = "";
        }
    }
}
