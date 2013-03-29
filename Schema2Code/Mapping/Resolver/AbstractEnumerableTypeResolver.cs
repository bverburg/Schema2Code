using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using AutoMapper;
using Ninject;
using Schema2Code.Code;

namespace Schema2Code.Mapping.Resolver
{
    public abstract class AbstractEnumerableTypeResolver : AbstractValueResolver<XmlSchemaElement, IType>
    {
        [Inject]
        public ITypeRegister TypeRegister { get; set; }
    }
}
