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
    public class TypeNameResolver : AbstractTypeNameResolver
    {
        public override IQualifiedName Resolve(XmlSchemaElement source)
        {
            return AutoMapper.Mapper.Map<IQualifiedName>(!source.IsAnonymousType() ? source.ElementSchemaType.QualifiedName : source.QualifiedName);
        }
    }
}
