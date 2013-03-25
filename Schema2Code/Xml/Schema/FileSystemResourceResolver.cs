using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace Schema2Code.Xml.Schema
{
    public class FileSystemResourceResolver : XmlResolver
    {
        public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
        {
            var reader = XmlReader.Create(absoluteUri.LocalPath);
            return XmlSchema.Read(reader, ValidationCallback);
        }

        public override ICredentials Credentials
        {
            set { throw new NotImplementedException(); }
        }

        static void ValidationCallback(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
                Console.Write("WARNING: ");
            else if (args.Severity == XmlSeverityType.Error)
                Console.Write("ERROR: ");

            Console.WriteLine(args.Message);
        }
    }
}
