using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using Schema2Code.Code;
using Schema2Code.Mapping.Resolver;

namespace Schema2Code.CSharp.Mapping.Resolver
{
    public class PropertiesResolver : AbstractPropertiesResolver
    {
        protected override IProperty ResolveCore(XmlSchemaObject source)
        {
            return null;
        }
    }
}
