using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Imposto.Core.Service
{
    public static class XmlService
    {
        public static void SalvarXml<T>(T obj, string filePath)
        {
            lock (obj)
            {
                var serializer = new XmlSerializer(obj.GetType());
                var nameSpace = new XmlSerializerNamespaces();
                var format = new XmlWriterSettings { Indent = true, NewLineOnAttributes = true, OmitXmlDeclaration = true };
                nameSpace.Add("","");

                using (XmlWriter writer = XmlWriter.Create(filePath, format))
                {
                    serializer.Serialize(writer, obj);
                }
            }
        }
    }
}
