using System;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.UnitTests
{
    [TestFixture]
    public class XmlServiceTest
    {
        [Test]
        public void TestReadXml()
        {
            MetadataItem item = XmlService.ReadXML(@"C:\workspace\HF\Semester_2\ZbW.Testing.Dms\ZbW.Testing.Dms_Aufgabe\ZbW.Testing.Dms.Client.UnitTests\DMSTest\2019/5be309a6-82d1-4aec-a241-938ce3cbcc6c_Metadata.xml");
            Assert.IsNotNull(item);
            Assert.AreEqual("Joshua", item.Benutzer);
            Assert.AreEqual("Test Quittungen", item.Bezeichnung);
        }

        [Test]
        public void TestWriteXml()
        {
            MetadataItem item = new MetadataItem();
            item.ValutaDatum = DateTime.Now;
            item.FilePath = @"..\..\DMSTest\test.txt";
            item.Benutzer = "Joshua";
            item.Bezeichnung = "Test Quittungen";
            item.Erfassungsdatum = DateTime.Now;
            item.IsRemoveFileEnabled = false;
            item.SelectedTypItem = "Quittungen";
            item.Stichwoerter = "Test Quittungen";
            string documentFile = XmlService.WriteXML(item, ConfigService.GetConfigValueByKey("RepositoryDir") + "/test.txt");

            MetadataItem item2 = XmlService.ReadXML(documentFile);
            Assert.IsNotNull(item2);
            Assert.AreEqual("Joshua", item2.Benutzer);
            Assert.AreEqual("Test Quittungen", item2.Bezeichnung);

        }
    }
}
