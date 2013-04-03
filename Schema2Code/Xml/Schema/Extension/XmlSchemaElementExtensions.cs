using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using Schema2Code.Xml.Util;

namespace Schema2Code.Xml.Schema.Extension
{
    public static class XmlSchemaElementExtensions
    {
        public static List<XmlSchemaObject> SequenceObjects(this XmlSchemaElement element)
        {
            return XmlUtils.GetElementSequenceObjects(element);
        }

        public static bool IsAnonymousType(this XmlSchemaElement element)
        {
            return XmlUtils.IsAnonymousType(element.ElementSchemaType);
        }

        public static bool IsSimpleType(this XmlSchemaElement element)
        {
            return XmlUtils.IsSimpleType(element.ElementSchemaType);
        }

        public static bool IsComplexType(this XmlSchemaElement element)
        {
            return XmlUtils.IsComplexType(element.ElementSchemaType);
        }
    }
}
