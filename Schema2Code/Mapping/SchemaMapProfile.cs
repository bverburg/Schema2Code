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
                .ForMember(dest => dest.Name, opt => opt.ResolveUsing<AbstractNamespaceResolver>())
                .ConstructUsingServiceLocator();

            CreateMap<XmlQualifiedName, IQualifiedName>()
                .IgnoreAllUnmapped()
                .ForMember(dest => dest.Name, opt => { opt.AddFormatter<AbstractTypeNameFormatter>(); opt.MapFrom(src => src.Name); })
                .ForMember(dest => dest.NameSpace, opt => opt.MapFrom(src => src.Namespace))
                .ConstructUsingServiceLocator();

            CreateMap<XmlSchemaElement, IClass>()
                .IgnoreAllUnmapped()
                .ForMember(dest => dest.QualifiedName, opt => opt.ResolveUsing<AbstractTypeNameResolver>()) // opt.MapFrom(src => src.ElementSchemaType.QualifiedName))
                .ForMember(dest => dest.Members, opt => opt.ResolveUsing<AbstractMembersResolver>())
                .ForMember(dest => dest.Attributes, opt => opt.ResolveUsing<AbstractAttributesResolver>())
                .ConstructUsingServiceLocator();

            CreateMap<XmlSchemaElement, IType>()
                .IgnoreAllUnmapped()
                .ForMember(dest => dest.QualifiedName, opt => opt.MapFrom(src => src.ElementSchemaType.QualifiedName))

                .ConstructUsingServiceLocator();
            
            CreateMap<XmlSchemaElement, IMember>()
                .IgnoreAllUnmapped()
                .ForMember(dest => dest.Name, opt => { opt.AddFormatter<AbstractMemberNameFormatter>(); opt.MapFrom(src => src.Name); })
                .ForMember(dest => dest.Type, opt => opt.ResolveUsing<AbstractTypeResolver>()) //type valueResolver
                .ConstructUsingServiceLocator();

            CreateMap<XmlSchemaElement, IEnumerableMember>()
                .IgnoreAllUnmapped()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ItemName, opt => opt.ResolveUsing<AbstractEnumerableItemNameResolver>())
                .ForMember(dest => dest.Type, opt => opt.ResolveUsing<AbstractEnumerableTypeResolver>()) //type valueResolver
                .ConstructUsingServiceLocator();
        }
    }
}
