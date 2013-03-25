using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using Schema2Code.Xml.Schema;
using Xunit;

namespace Test
{
    public class Class1
    {
        [Fact]
        public void Test()
        {
            var schema = ReadAndCompileSchema("Resource/TestSchema.xsd");
            
            TraverseSOM(schema);


        }

        private static void TraverseSOM(XmlSchema custSchema)
        {
            foreach (XmlSchemaElement elem in
                             custSchema.Elements.Values)
            {
                ProcessElement(elem);
            }
        }

        private static XmlSchema ReadAndCompileSchema(string fileName)
        {
            var tr = XmlReader.Create(fileName);
            // The Read method will throw errors encountered
            // on parsing the schema
            var schema = XmlSchema.Read(tr, ValidationCallback);
            tr.Close();

            var xset = new XmlSchemaSet();
            xset.Add(schema);

            xset.ValidationEventHandler += ValidationCallback;

            // The Compile method will throw errors
            // encountered on compiling the schema
            xset.Compile();

            return schema;
        }

        static void ValidationCallback(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
                Console.Write("WARNING: ");
            else if (args.Severity == XmlSeverityType.Error)
                Console.Write("ERROR: ");

            Console.WriteLine(args.Message);
        }

        private static void ProcessElement(XmlSchemaElement elem)
        {
            Console.WriteLine("Element: {0}", elem.Name);

            if (elem.ElementSchemaType is XmlSchemaComplexType)
            {
                XmlSchemaComplexType ct =
                    elem.ElementSchemaType as XmlSchemaComplexType;

                foreach (DictionaryEntry obj in ct.AttributeUses)
                    Console.WriteLine("Attribute: {0}  ",
                    (obj.Value as XmlSchemaAttribute).Name);

                ProcessSchemaObject(ct.ContentTypeParticle);
            }
        }

        private static void ProcessSequence(XmlSchemaSequence sequence)
        {
            Console.WriteLine("Sequence");
            ProcessItemCollection(sequence.Items);
        }

        private static void ProcessChoice(XmlSchemaChoice choice)
        {
            Console.WriteLine("Choice");
            ProcessItemCollection(choice.Items);
        }

        private static void ProcessItemCollection(XmlSchemaObjectCollection objs)
        {
            foreach (XmlSchemaObject obj in objs)
                ProcessSchemaObject(obj);
        }

        private static void ProcessSchemaObject(XmlSchemaObject obj)
        {
            if (obj is XmlSchemaElement)
                ProcessElement(obj as XmlSchemaElement);
            if (obj is XmlSchemaChoice)
                ProcessChoice(obj as XmlSchemaChoice);
            if (obj is XmlSchemaSequence)
                ProcessSequence(obj as XmlSchemaSequence);
        }
    }
}
