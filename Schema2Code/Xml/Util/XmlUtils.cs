using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using NLog;

namespace Schema2Code.Xml.Util
{
    public class XmlUtils
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static bool IsAnonymousType(XmlSchemaType type)
        {
            return type.QualifiedName.IsEmpty;
        }
        
        public static bool IsSimpleType(XmlSchemaType type)
        {
            return type is XmlSchemaSimpleType;
        }

        public static bool IsComplexType(XmlSchemaType type)
        {
            return type is XmlSchemaComplexType;
        }

        public static List<XmlSchemaObject> GetElementSequenceObjects(XmlSchemaElement element)
        {
            var complexType = GetXmlSchemaType<XmlSchemaComplexType>(element);
            var pa = GetXmlSchemaComplexTypeContent<XmlSchemaSequence>(complexType);

            return pa.Items.Cast<XmlSchemaObject>().ToList();
        }

        public static T GetXmlSchemaComplexTypeContent<T>(XmlSchemaComplexType type) where T : XmlSchemaParticle
        {
            if (type.ContentTypeParticle is T)
            {
                return (T) type.ContentTypeParticle;
            }

            throw new ArgumentException(String.Format("Type {0} does not contain a {1} particle.", type.Name, typeof(T).Name));
        }

        public static T GetXmlSchemaType<T>(XmlSchemaElement element) where T:XmlSchemaType
        {
            if (element.ElementSchemaType is T)
            {
                return (T) element.ElementSchemaType;
            }

            throw new ArgumentException(String.Format("Element {0} does not contain a {1} definition.", element.Name, typeof(T).Name));
        }

        public static XmlSchema ReadAndCompileSchema(string fileName, ValidationEventHandler handler)
        {
            var tr = XmlReader.Create(fileName);
            // The Read method will throw errors encountered
            // on parsing the schema
            var schema = XmlSchema.Read(tr, handler);
            tr.Close();

            var xset = new XmlSchemaSet();
            xset.Add(schema);

            xset.ValidationEventHandler += handler;

            // The Compile method will throw errors
            // encountered on compiling the schema
            xset.Compile();

            return schema;
        }

        public static void DefaultValidationCallback(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
                Logger.Warn(args.Message);
            else if (args.Severity == XmlSeverityType.Error)
                Logger.Error(args.Message);
        }

    }
}
