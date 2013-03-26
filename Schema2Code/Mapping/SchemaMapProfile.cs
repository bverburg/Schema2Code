using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using AutoMapper;
using Schema2Code.Code;
using Schema2Code.Mapping;
using Schema2Code.Mapping.Formatter;
using Schema2Code.Mapping.Resolver;

namespace Schema2Code.Mapping
{
    public class SchemaMapProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<string, INamespace>()
                .ForMember(dest => dest.Name, opt => { opt.MapFrom(src=>src); opt.AddFormatter<AbstractNamespaceFormatter>(); })
                .ConstructUsingServiceLocator();

            CreateMap<XmlQualifiedName, IQualifiedName>()
                .IgnoreAllUnmapped()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.NameSpace, opt => opt.MapFrom(src => src.Namespace))
                .ConstructUsingServiceLocator();

            CreateMap<XmlSchemaComplexType, IType>()
                .IgnoreAllUnmapped()
                .ForMember(dest => dest.QualifiedName, opt => opt.MapFrom(src=>src.QualifiedName))
                .ConstructUsingServiceLocator();
        }
    }
}
