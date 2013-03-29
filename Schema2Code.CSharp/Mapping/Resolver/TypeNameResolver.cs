using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using Schema2Code.Code;
using Schema2Code.Mapping.Resolver;

namespace Schema2Code.CSharp.Mapping.Resolver
{
    public class TypeNameResolver : AbstractTypeNameResolver
    {
        public override IQualifiedName Resolve(XmlSchemaElement source)
        {
            var anon = source.ElementSchemaType.QualifiedName.IsEmpty;
            return AutoMapper.Mapper.Map<IQualifiedName>(!anon ? source.ElementSchemaType.QualifiedName : source.QualifiedName);
        }
    }
}
