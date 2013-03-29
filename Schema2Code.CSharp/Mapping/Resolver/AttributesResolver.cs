using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using Schema2Code.Code;
using Schema2Code.Mapping.Resolver;

namespace Schema2Code.CSharp.Mapping.Resolver
{
    public class AttributesResolver : AbstractAttributesResolver
    {
        public override List<IAttribute> Resolve(XmlSchemaElement @from)
        {
            return null;
        }
    }
}
