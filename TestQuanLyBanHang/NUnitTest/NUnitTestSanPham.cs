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
            new SanPham("sp01", "Bàn", "Cái", "55000"), //Trường hợp nhập đầy đủ thông tin
        };

        [TestCaseSource(nameof(SanPhamForTestAdd))]

        public void TestAdd(SanPham p)
        {
            Assert.Positive(spDAO.Add(p)); //Nếu giá trị trả về > 0 là đúng         
        }

        static SanPham[] SanPhamForTestAdd2 =
        {
            new SanPham("", "Cửa", "Cái", "65000"), //Trường hợp không nhập mã sản phẩm
            new SanPham("sp02", "", "Cái", "65000"), //Trường hợp không nhập tên sản phẩm
            new SanPham("sp03", "Tủ" , "", "65000"), //Trường hợp không nhập đơn vị tính
            new SanPham("sp04", "Ghế" , "Cái", ""), //Trường hợp không nhập đơn giá
            //new SanPham("sp005","Sữa","Hộp","10000") //Trường hợp nhập mã sp quá 4 ký tự

        };

        [TestCaseSource(nameof(SanPhamForTestAdd2))]
        public void TestAdd2(SanPham p)
        {
            Assert.Negative(spDAO.Add(p)); //Nếu giá trị trả về < 0 là đúng    
        }

        //static SanPham[] SanPhamForTestAdd3 =
        //{
        //    new SanPham("sp01", "Bàn", "Cái", "55000"), //Trường hợp nhập trùng sản phẩm đã có
        //};

        //[TestCaseSource(nameof(SanPhamForTestAdd3))]
        //public void TestAdd3(SanPham p)
        //{
        //    Assert.Negative(spDAO.Add(p)); //Nếu giá trị trả về < 0 là đúng    
        //}

        [TestCase("sp01", Description = "Xóa sản phẩm")]
        public void TestDelete(string id)
        {
            Assert.Positive(spDAO.Delete(id)); //Nếu giá trị trả về > 0 là đúng    
        }

        static SanPham[] SanPhamForTestUpdate =
        {
            new SanPham("sp02", "Bánh", "Cái", "55000"), //Đổi tên cho sp có mã sp02
            
        };
        [TestCaseSource(nameof(SanPhamForTestUpdate))]
        public void TestUpdate(SanPham sp)
        {
            Assert.Positive(spDAO.Update(sp));
        }
    }
}
