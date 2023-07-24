using System.Reflection.Metadata;

namespace FinalProjectTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGoodLogin()

        {
            NguyenThaoMinh_2121110235.User oUser =new NguyenThaoMinh_2121110235.User();
            Assert.AreEqual(true,oUser.Login("admin","123456"),"admin/123456 should be good login");
        }

        [Test]
        public void TestBadLogin()

        {
            NguyenThaoMinh_2121110235.User oUser = new NguyenThaoMinh_2121110235.User();
            Assert.AreEqual(true, oUser.Login("admin", "I forgot my password *^&!$"), "admin/anything else should be bad login");
        }
    }
}