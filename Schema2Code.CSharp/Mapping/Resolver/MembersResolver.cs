using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using Schema2Code.CSharp.Code;
using Schema2Code.Code;
using Schema2Code.Mapping.Resolver;
using Schema2Code.Xml.Schema.Extension;

namespace Schema2Code.CSharp.Mapping.Resolver
{
    public class MembersResolver : AbstractMembersResolver
    {
        public override List<IMember> Resolve(XmlSchemaElement source)
        {
            var properties = new List<IMember>();

            foreach (var item in source.SequenceObjects())
            {
                var propertyElement = item as XmlSchemaElement;
                if (propertyElement != null)
                {
                    IMember member = null;

                    if (!propertyElement.IsAnonymousType())
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
