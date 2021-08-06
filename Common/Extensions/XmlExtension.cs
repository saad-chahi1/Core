using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace SSI.GeoVision.Common.Extensions
{
    public class XmlExtension
    {
        public static T Deserialize<T>(string xmlContent)
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(xmlContent)))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stream);
            }
        }

        public string Serialize<T>(T ObjectToSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, ObjectToSerialize);
                return textWriter.ToString();
            }
        }
    }
}
