using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using AutoMapper;
using Ninject;
using Schema2Code.Code;
using Schema2Code.Xml.Schema.Extension;

namespace Schema2Code.Mapping.Resolver
{
    public abstract class AbstractEnumerableTypeResolver : AbstractValueResolver<XmlSchemaElement, IType>
    {
        protected ITypeRegister TypeRegister { get; set; }
        protected IMappingEngine MappingEngine { get; set; }

        protected AbstractEnumerableTypeResolver(ITypeRegister register, IMappingEngine mappingEngine)
        {
            this.TypeRegister = register;
            this.MappingEngine = mappingEngine;
        }

        public override IType Resolve(XmlSchemaElement source)
        {
            var item = source.SequenceObjects()[0] as XmlSchemaElement;
            if (item.IsComplexType())
                return MappingEngine.Map<IClass>(item);
            if (item.IsSimpleType())
                return MappingEngine.Map<IType>(item);


            return null;
        }
    }
}
