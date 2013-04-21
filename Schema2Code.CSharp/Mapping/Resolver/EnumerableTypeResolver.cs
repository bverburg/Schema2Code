using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using AutoMapper;
using Schema2Code.Code;
using Schema2Code.Mapping.Resolver;
using Schema2Code.Xml.Schema.Extension;

namespace Schema2Code.CSharp.Mapping.Resolver
{
    public class EnumerableTypeResolver : AbstractEnumerableTypeResolver
    {
        public EnumerableTypeResolver(ITypeRegister register,IMappingEngine mappingEngine) : base(register, mappingEngine)
        {
        }
    }
}
