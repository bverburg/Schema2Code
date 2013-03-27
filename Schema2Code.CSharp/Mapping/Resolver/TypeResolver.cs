using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using Schema2Code.Code;
using Schema2Code.Mapping.Resolver;

namespace Schema2Code.CSharp.Mapping.Resolver
{
    public class TypeResolver : AbstractTypeResolver
    {
        protected override IType ResolveCore(XmlSchemaElement source)
        {
            var type = source.ElementSchemaType;
            if(type is XmlSchemaComplexType)
                return AutoMapper.Mapper.Map<IClass>(source);
            if(type is XmlSchemaSimpleType)
                return AutoMapper.Mapper.Map<IType>(source);

            return null;
        }
    }
}
