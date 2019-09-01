using System;
using System.IO;
using System.Xml.Serialization;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services
{
    public static class XmlService
    {

        public static MetadataItem ReadXML(string filePath)
        {
            XmlSerializer reader = new XmlSerializer(typeof(MetadataItem));
            StreamReader file = new StreamReader(filePath);
            MetadataItem metadataItem = (MetadataItem)reader.Deserialize(file);
            file.Close();
            return metadataItem;
        }

        public static string WriteXML(MetadataItem metadataItem, string filePath)
        {
            {
                XmlSerializer writer = new XmlSerializer(typeof(MetadataItem));
                FileStream fs = null;
                var path = ConfigService.GetConfigValueByKey("RepositoryDir");

                path += "/" + metadataItem.ValutaDatum.Value.Year;

                // If directory does not exist, create it. 
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                Guid guid = Guid.NewGuid();

                var metadataFile = path + "//" + guid.ToString() + "_Metadata.xml";
                var documentFile = path + "//" + guid.ToString() + "_Content" + new FileInfo(filePath).Extension;
                metadataItem.FilePath = documentFile;
                fs = File.Create(metadataFile);
                File.Copy(filePath, documentFile, true);
                writer.Serialize(fs, metadataItem);
                fs.Close();
                return documentFile;
            }
        }

    }
}
