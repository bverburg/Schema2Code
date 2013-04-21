using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using AutoMapper;
using Ninject;
using Schema2Code.CSharp.Inject;
using Schema2Code.Code;
using Schema2Code.Inject;
using Schema2Code.Mapping;
using Schema2Code.Xml.Schema;
using Xunit;

namespace Test
{
    public class Class1
    {
        [Fact]
        public void Test()
        {
            var kernel = new StandardKernel(new CodeModule(), new AutoMapperModule());
            var mappingEngine = kernel.Get<IMappingEngine>();
            var schema = ReadAndCompileSchema("Resource/TestSchema.xsd");
            var list = TraverseSom(schema, mappingEngine);
            foreach (var type in list)
            {
                PrintTree(type,String.Empty,false);
            }

        }

        private static void PrintTree(ITyped typed, String indent, bool last)
        {
            
        }
        
        private static void PrintTree(IType type, String indent, bool last)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("\\-");
                indent += "  ";
            }
            else
            {
                Console.Write("|-");
                indent += "| ";
            }
            Console.WriteLine(type);

            if(type is IClass)
            {
                var clas = type as IClass;

                foreach (var member in clas.Members)
                {
                    PrintTree(member.Type,indent,false);
                }
            }

            
        }

        private static List<IType> TraverseSom(XmlSchema custSchema, IMappingEngine mappingEngine)
        {
            return (from XmlSchemaElement elem in custSchema.Elements.Values select ProcessType(elem, mappingEngine)).ToList();
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

        
        private static IType ProcessType(XmlSchemaElement elem, IMappingEngine mappingEngine)
        {
            return mappingEngine.Map<IClass>(elem);
        }
    }
}
