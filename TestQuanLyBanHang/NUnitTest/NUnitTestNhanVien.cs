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
            new NhanVien("E01","Le","Lam","123 THD","0913930"), //Trường hợp nhập đầy đủ thông tin
        };

        [TestCaseSource(nameof(NhanVienForTestAdd))]
        public void TestAdd(NhanVien e)
        {
            Assert.Positive(nvDAO.Add(e)); //Nếu giá trị trả về >0 là đúng
        }

        static NhanVien[] NhanVienForTestAdd2 =
        {
            //new NhanVien("nv02",null,"Nguyen","Teo","2390 BS","098098"), //Trường hợp không nhập mã nhân viên
            new NhanVien("E02",null,"Ti","230 BS","029390"), //Trường hợp không nhập họ nhân viên
            new NhanVien("E03","Nguyen",null,"230 BSA","090098"), //Trường hợp không nhập tên nhân viên
            new NhanVien("E04","Pham","A",null,"0903930"), //Trường hợp không nhập địa chỉ
            new NhanVien("E05","Ngo","Kha","39 THD",null), //Trường hợp không nhập số điện thoại
            new NhanVien("E0005","Tran","Ngoc","34 HM","093203"), //Trường hợp nhập mã nv quá 4 ký tự
        };

        [TestCaseSource(nameof(NhanVienForTestAdd2))]
        public void TestAdd2(NhanVien e)
        {
            Assert.Negative(nvDAO.Add(e)); //Nếu giá trị trả về <0 là đúng
        }

        static NhanVien[] NhanVienForTestAdd3 =
        {
            new NhanVien("E01","Le","Lam","123 THD", "0913930") //Trường hợp nhập nhân viên đã tồn tại trong danh sách
        };

        [TestCaseSource(nameof(NhanVienForTestAdd3))]
        public void TestAdd3(NhanVien e)
        {
            Assert.Negative(nvDAO.Add(e)); //Nếu giá trị trả về <0 là đúng
        }

        [TestCase("E01", Description = "Xóa nhân viên")]
        public void TestDelete(string id)
        {
            Assert.Positive(nvDAO.Delete(id)); //Nếu giá trị trả về > 0 là đúng    
        }

        static NhanVien[] NhanVienForTestUpdate =
        {
            new NhanVien("E02", "Lê", "Ti","230 BS","029390"), //Đổi tên cho nv có mã E02
        };
        [TestCaseSource(nameof(NhanVienForTestUpdate))]
        public void TestUpdate(NhanVien nv)
        {
            Assert.Positive(nvDAO.Update(nv));
        }
    }
}
