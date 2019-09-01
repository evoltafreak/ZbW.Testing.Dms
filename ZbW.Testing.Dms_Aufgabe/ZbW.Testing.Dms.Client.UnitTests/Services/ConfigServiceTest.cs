using NUnit.Framework;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.UnitTests
{
    [TestFixture]
    public class ConfigServiceTest
    {
        [Test]
        public void TestGetConfigValueByKey()
        {
            string repositoryDir = ConfigService.GetConfigValueByKey("RepositoryDir");
            Assert.IsNotNull(repositoryDir);
            Assert.AreEqual(repositoryDir, @"..\..\DMSTest");
        }
    }
}
