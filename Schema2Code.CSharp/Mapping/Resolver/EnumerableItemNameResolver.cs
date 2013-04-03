using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using Schema2Code.Mapping.Resolver;
using Schema2Code.Xml.Schema.Extension;

namespace Schema2Code.CSharp.Mapping.Resolver
{
    public class EnumerableItemNameResolver : AbstractEnumerableItemNameResolver
    {
        public override string Resolve(XmlSchemaElement source)
        {
            var item = source.SequenceObjects()[0] as XmlSchemaElement;
            return item.Name;
        }
    }
}
