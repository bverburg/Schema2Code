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
    public class TypeResolver : AbstractTypeResolver
    {
        public override IType ResolveType(XmlSchemaElement source)
        {
            if (source.IsComplexType())
            {
                return AutoMapper.Mapper.Map<IClass>(source);
            }
            if (source.IsSimpleType())
            {

                var elementType = (XmlSchemaSimpleTypeRestriction)((XmlSchemaSimpleType)source.ElementSchemaType).Content;
                if (elementType.Facets.Count > 0)
                {

                }
                return AutoMapper.Mapper.Map<IType>(source);
            }
            return null;
        }
    }
}
