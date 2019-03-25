using System;
using NUnit;
using NUnit.Framework;
using DTO;
using DAO;

namespace TestQuanLyBanHang.NUnitTest
{
    [TestFixture]
    public class NUnitTestSanPham
    {
        SanPhamDAO spDAO;
        [SetUp]
        public void Load()
        {
            spDAO = new SanPhamDAO();
        }
        static SanPham[] SanPhamForTestAdd =
        {
            //new SanPham("TH04", "Áo thần", "Cái", "55000"),
            new SanPham(null, "Chai nước", "Chai", "15000"),
            new SanPham("ND01", null, "Chai", "15000"),
            new SanPham("ND01", "Chai nước" , null, "15000"),
            new SanPham("ND01", "Chai nước" , "Chai", null)
        };

        [TestCaseSource(nameof(SanPhamForTestAdd))]
        public void TestAdd(SanPham p)
        {
            Assert.Positive(spDAO.Add(p)); // bắt giá trị trả về nếu > 0 là đúng         
        }
        
    }
}
