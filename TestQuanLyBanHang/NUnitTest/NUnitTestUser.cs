using System;
using NUnit;
using NUnit.Framework;
using DTO;
using DAO;

namespace TestQuanLyBanHang.NUnitTest
{
    [TestFixture]
    public class NUnitTestUser
    {
        UsersDAO userDAO;
        [SetUp]
        public void Load()
        {
            userDAO = new UsersDAO();
        }

        [TestCase("admin", "12345", true, Description = "Trường hợp login thành công")]
        [TestCase("us1", "12345", true, Description = "Trường hợp login thành công")]
        [TestCase("us2", "12345", true, Description = "Trường hợp login thành công")]
        [TestCase("admin", "12345123", false, Description = "Trường hợp sai password")]
        [TestCase("admin123", "12345", false, Description = "Trường hợp sai username")]
        [TestCase("admin", "", false, Description = "Trường hợp không nhập password")]
        [TestCase("", "12345", false, Description = "Trường hợp không nhập username")]

        public void TestLogin(string userName, string password, bool expected)
        {
            Assert.AreEqual(expected, userDAO.Login(userName, password));
        }

        static Users[] UsersForTestAdd =
        {
            new Users("us3", "P@ssword01"), //Trường hợp nhập username chưa có và pass hợp lệ
        };

        [TestCaseSource(nameof(UsersForTestAdd))]
        public void TestAdd(Users u)
        {
            Assert.Positive(userDAO.Add(u)); //Nếu giá trị trả về >0 là đúng
        }

        static Users[] UsersForTestAdd2 =
        {
            //new Users("us2", "12345"), //Trường hợp nhập username đã có
            new Users("us4", "password"), //Trường hợp nhập password không hợp lệ
            //new Users("us55555555555555555555", "P@ssword01"), //Trường hợp nhập username quá dài
            new Users("","P@ssword01"), //Trường hợp không nhập username
        };

        [TestCaseSource(nameof(UsersForTestAdd2))]
        public void TestAdd2(Users u)
        {
            Assert.Negative(userDAO.Add(u)); //Nếu giá trị trả về <0 là đúng
        }

      
    }
}
