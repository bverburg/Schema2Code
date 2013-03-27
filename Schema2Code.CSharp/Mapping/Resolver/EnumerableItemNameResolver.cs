using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using Schema2Code.Mapping.Resolver;

namespace Schema2Code.CSharp.Mapping.Resolver
{
    public class EnumerableItemNameResolver : AbstractEnumerableItemNameResolver
    {
        protected override string ResolveCore(XmlSchemaElement source)
        {
            var complex = source.ElementSchemaType as XmlSchemaComplexType;
            var sequence = complex.ContentTypeParticle as XmlSchemaSequence;

            var item = sequence.Items[0] as XmlSchemaElement;
            return item.Name;
        }
    }
}
