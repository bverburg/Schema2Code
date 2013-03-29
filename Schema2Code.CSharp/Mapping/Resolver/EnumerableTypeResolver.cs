using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using Schema2Code.Code;
using Schema2Code.Mapping.Resolver;

namespace Schema2Code.CSharp.Mapping.Resolver
{
    public class EnumerableTypeResolver : AbstractEnumerableTypeResolver
    {
        public override IType Resolve(XmlSchemaElement source)
        {
            var complex = source.ElementSchemaType as XmlSchemaComplexType;
            var sequence = complex.ContentTypeParticle as XmlSchemaSequence;

            var item = sequence.Items[0] as XmlSchemaElement;
            if (item.ElementSchemaType is XmlSchemaComplexType)
                return AutoMapper.Mapper.Map<IClass>(item);
            if (item.ElementSchemaType is XmlSchemaSimpleType)
                return AutoMapper.Mapper.Map<IType>(item);

            
            return null;
        }
    }
}
