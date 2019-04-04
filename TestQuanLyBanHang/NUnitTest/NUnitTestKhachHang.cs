using System;
using NUnit;
using NUnit.Framework;
using DTO;
using DAO;

namespace TestQuanLyBanHang.NUnitTest
{
    [TestFixture]
    public class NUnitTestKhachHang
    {
        KhachHangDAO khDAO;
        [SetUp]
        public void Load()
        {
            khDAO = new KhachHangDAO();
        }
        static KhachHang[] KhachHangForTestAdd =
        {
            new KhachHang("C01","A","320 BS","09309","09043"), //Trường hợp nhập đầy đủ thông tin
            new KhachHang("C06","E","930 HN","09304",null), //Trường hợp không nhập số fax
        };

        [TestCaseSource(nameof(KhachHangForTestAdd))]
        public void TestAdd(KhachHang c)
        {
            Assert.Positive(khDAO.Add(c)); //Nếu giá trị trả về >0 là đúng
        }

        static KhachHang[] KhachHangForTestAdd2 =
        {
            new KhachHang(null,"B","3902 THD","09302","0930"), //Trường hợp không nhập mã KH
            new KhachHang("C03",null,"3209 LL","0930","0938"), //Trường hợp không nhập tên KH
            new KhachHang("C04","C",null,"0930","0930"), //Trường hợp không nhập địa chỉ KH
            new KhachHang("C05","D","09 LL",null,"09309"), //Trường hợp không nhập số điện thoại KH
            new KhachHang("C0006","E","239 LL","092309","092809"), //Trường hợp nhập mã KH quá 4 ký tự
        };

        [TestCaseSource(nameof(KhachHangForTestAdd2))]
        public void TestAdd2(KhachHang c)
        {
            Assert.Negative(khDAO.Add(c)); //Nếu giá trị trả về <0 là đúng
        }

        static KhachHang[] KhachHangForTestAdd3 =
        {
            new KhachHang("C01","A","320 BS","09309","09043") //Trường hợp nhập trùng thông tin 
        };

        [TestCaseSource(nameof(KhachHangForTestAdd3))]
        public void TestAdd3(KhachHang c)
        {
            Assert.Negative(khDAO.Add(c)); //Nếu giá trị trả về <0 là đúng
        }
    }
}
