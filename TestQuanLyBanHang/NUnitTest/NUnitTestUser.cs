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
        [TestCase("admin", " ", false, Description = "Trường hợp không nhập password")]
        [TestCase("admin123", "12345", false, Description = "Trường hợp sai username")]
        [TestCase(" ", "12345", false, Description = "Trường hợp không nhập username")]
        public void TestLogin(string userName, string password, bool expected)
        {
            Assert.AreEqual(expected, userDAO.Login(userName, password));
        }


    }
}
