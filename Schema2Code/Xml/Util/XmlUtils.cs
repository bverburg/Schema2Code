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


        public static XmlSchema ReadAndCompileSchema(string fileName)
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

        private static void ValidationCallback(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
                Console.Write("WARNING: ");
            else if (args.Severity == XmlSeverityType.Error)
                Console.Write("ERROR: ");

            Console.WriteLine(args.Message);
        }
    }
}
