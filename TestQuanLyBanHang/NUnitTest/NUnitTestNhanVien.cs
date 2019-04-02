using System;
using NUnit;
using NUnit.Framework;
using DTO;
using DAO;

namespace TestQuanLyBanHang.NUnitTest
{
    [TestFixture]
    public class NUnitTestNhanVien
    {
        NhanVienDAO nvDAO;
        [SetUp]
        public void Load()
        {
            nvDAO = new NhanVienDAO();
        }
        static NhanVien[] NhanVienForTestAdd =
        {
            new NhanVien("nv01","Le","Lam","123 THD","0913930"), //Trường hợp nhập đầy đủ thông tin
        };

        [TestCaseSource(nameof(NhanVienForTestAdd))]
        public void TestAdd(NhanVien e)
        {
            Assert.Positive(nvDAO.Add(e)); //Nếu giá trị trả về >0 là đúng
        }

        static NhanVien[] NhanVienForTestAdd2 =
        {
            //new NhanVien("nv02",null,"Nguyen","Teo","2390 BS","098098"), //Trường hợp không nhập mã nhân viên
            new NhanVien("nv02",null,"Ti","230 BS","029390"), //Trường hợp không nhập họ nhân viên
            new NhanVien("nv03","Nguyen",null,"230 BSA","090098"), //Trường hợp không nhập tên nhân viên
            new NhanVien("nv04","Pham","A",null,"0903930"), //Trường hợp không nhập địa chỉ
            new NhanVien("nv05","Ngo","Kha","39 THD",null), //Trường hợp không nhập số điện thoại
        };

        [TestCaseSource(nameof(NhanVienForTestAdd2))]
        public void TestAdd2(NhanVien e)
        {
            Assert.Negative(nvDAO.Add(e)); //Nếu giá trị trả về <0 là đúng
        }

        static NhanVien[] NhanVienForTestAdd3 =
        {
            new NhanVien("nv01","Le","Lam","123 THD", "0913930") //Trường hợp nhập nhân viên đã tồn tại trong danh sách
        };

        [TestCaseSource(nameof(NhanVienForTestAdd3))]
        public void TestAdd3(NhanVien e)
        {
            Assert.Negative(nvDAO.Add(e)); //Nếu giá trị trả về <0 là đúng
        }
    }
}
