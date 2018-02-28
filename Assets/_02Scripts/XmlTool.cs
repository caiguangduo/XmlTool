using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Text;
/// <summary>
/// 序列化输入输出XML的工具
/// </summary>
public class XmlTool
{
    public static T DeserializeObject<T>(string content)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(content));
        return (T)serializer.Deserialize(memoryStream);
    }

    public static string SerializeObject<T>(T obj, bool Format = true)
    {
        MemoryStream memoryStream = new MemoryStream();
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
        xmlTextWriter.Namespaces = false;
        if (Format)
        {
            xmlTextWriter.Formatting = Formatting.Indented;
            xmlTextWriter.Indentation = 1;
            xmlTextWriter.IndentChar = '\t';
            serializer.Serialize(xmlTextWriter, obj);
        }
        else
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            serializer.Serialize(xmlTextWriter, obj, ns);
        }
        memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
        return UTF8ByteArrayToString(memoryStream.ToArray());
    }

    private static string UTF8ByteArrayToString(byte[] characters)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        string constructedString = encoding.GetString(characters);
        return (constructedString);
    }

    private static byte[] StringToUTF8ByteArray(string pXmlString)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        byte[] byteArray = encoding.GetBytes(pXmlString);
        return byteArray;
    }
}