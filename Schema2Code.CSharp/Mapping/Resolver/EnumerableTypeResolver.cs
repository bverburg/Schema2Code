using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using Schema2Code.Code;
using Schema2Code.Mapping.Resolver;
using Schema2Code.Xml.Schema.Extension;

namespace Schema2Code.CSharp.Mapping.Resolver
{
    public class EnumerableTypeResolver : AbstractEnumerableTypeResolver
    {
        public override IType Resolve(XmlSchemaElement source)
        {
            var item = source.SequenceObjects()[0] as XmlSchemaElement;
            if (item.IsComplexType())
                return AutoMapper.Mapper.Map<IClass>(item);
            if (item.IsSimpleType())
                return AutoMapper.Mapper.Map<IType>(item);

            
            return null;
        }
    }
}
