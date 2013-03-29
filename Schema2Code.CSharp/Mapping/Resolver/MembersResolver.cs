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
    public class MembersResolver : AbstractMembersResolver
    {
        protected override List<IMember> ResolveCore(XmlSchemaElement source)
        {
            var complexType = source.ElementSchemaType as XmlSchemaComplexType;
            var xmlSequence = complexType.ContentTypeParticle as XmlSchemaSequence;

            var properties = new List<IMember>();

            foreach (var item in xmlSequence.Items)
            {
                var propertyElement = item as XmlSchemaElement;
                if (propertyElement != null)
                {
                    IMember member = null;

                    if (!propertyElement.ElementSchemaType.QualifiedName.IsEmpty)
                    {
                        member = AutoMapper.Mapper.Map<IMember>(propertyElement);
                    }
                    else
                    {
                        member = AutoMapper.Mapper.Map<IEnumerableMember>(propertyElement);
                    }

                    if(member != null)
                        properties.Add(member);
                }
                    
            }
            return properties;
        }
    }
}
