using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NUnit.Framework;
using Moq;

    [TestFixture]
public class LoginTests
{
    private Mock<User> mockUser;

    [SetUp]
    public void Setup()
    {
        // Khởi tạo đối tượng mock cho User
        mockUser = new Mock<User>();
    }

    [Test]
    public void Test_ValidLogin_ReturnsTrue()
    {
        // Arrange
        string username = "testuser";
        string password = "testpassword";

        // Thiết lập dữ liệu cho đối tượng mock
        mockUser.Setup(u => u.Login(username, password)).Returns(true);

        // Tạo đối tượng form đăng nhập với đối tượng mockUser
        frmLogin loginForm = new frmLogin(mockUser.Object);

        // Act
        loginForm.btnDangNhap_Click(null, null);

        // Assert
        // Kiểm tra xem thông báo "Đăng nhập thành công" đã xuất hiện hay không
        Assert.IsTrue(loginForm.ShowDialogCalled);
        Assert.AreEqual("Đăng nhập thành công", loginForm.MessageShown);
    }

    [Test]
    public void Test_InvalidLogin_ReturnsFalse()
    {
        // Arrange
        string username = "invaliduser";
        string password = "invalidpassword";

        // Thiết lập dữ liệu cho đối tượng mock
        mockUser.Setup(u => u.Login(username, password)).Returns(false);

        // Tạo đối tượng form đăng nhập với đối tượng mockUser
        frmLogin loginForm = new frmLogin(mockUser.Object);

        // Act
        loginForm.btnDangNhap_Click(null, null);

        // Assert
        // Kiểm tra xem thông báo "Đăng nhập thất bại, thử lại" đã xuất hiện hay không
        Assert.IsFalse(loginForm.ShowDialogCalled);
        Assert.AreEqual("Đăng nhập thất bại, thử lại", loginForm.MessageShown);
    }
}