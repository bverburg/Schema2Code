using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using Schema2Code.CSharp.Code;
using Schema2Code.Code;
using Schema2Code.Mapping.Resolver;

namespace Schema2Code.CSharp.Mapping.Resolver
{
    public class PropertiesResolver : AbstractPropertiesResolver
    {
        protected override List<IProperty> ResolveCore(XmlSchemaElement source)
        {
            var complexType = source.ElementSchemaType as XmlSchemaComplexType;
            var xmlSequence = complexType.ContentTypeParticle as XmlSchemaSequence;

            var properties = new List<IProperty>();

            foreach (var item in xmlSequence.Items)
            {
                var propertyElement = item as XmlSchemaElement;
                if (propertyElement != null)
                {
                    IProperty property = null;

                    if (!propertyElement.ElementSchemaType.QualifiedName.IsEmpty)
                    {
                        property = AutoMapper.Mapper.Map<IProperty>(propertyElement);
                    }
                    else
                    {
                        property = AutoMapper.Mapper.Map<IEnumerableProperty>(propertyElement);
                    }

                    if(property != null)
                        properties.Add(property);
                }
                    
            }
            return properties;
        }
    }
}
