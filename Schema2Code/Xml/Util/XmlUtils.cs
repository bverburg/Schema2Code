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

        public static void ValidationCallback(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
                Logger.Warn(args.Message);
            else if (args.Severity == XmlSeverityType.Error)
                Logger.Error(args.Message);
        }
    }
}
