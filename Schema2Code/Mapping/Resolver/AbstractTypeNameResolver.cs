using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using AutoMapper;
using Schema2Code.Code;
using Schema2Code.Xml.Schema.Extension;

namespace Schema2Code.Mapping.Resolver
{
    public abstract class AbstractTypeNameResolver : AbstractValueResolver<XmlSchemaElement, IQualifiedName>
    {
        protected IMappingEngine MappingEngine { get; set; }

        protected AbstractTypeNameResolver(IMappingEngine mappingEngine)
        {
            this.MappingEngine = mappingEngine;
        }

        public override IQualifiedName Resolve(XmlSchemaElement source)
        {
            return MappingEngine.Map<IQualifiedName>(!source.IsAnonymousType() ? source.ElementSchemaType.QualifiedName : source.QualifiedName);
        }
    }
}
