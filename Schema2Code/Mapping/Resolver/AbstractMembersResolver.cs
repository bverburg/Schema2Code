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
    public abstract class AbstractMembersResolver : AbstractValueResolver<XmlSchemaElement, List<IMember>>
    {
        protected IMappingEngine MappingEngine { get; set; }

        protected AbstractMembersResolver(IMappingEngine mappingEngine)
        {
            this.MappingEngine = mappingEngine;
        }

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
                        member = MappingEngine.Map<IMember>(propertyElement);
                    }
                    else
                    {
                        member = MappingEngine.Map<IEnumerableMember>(propertyElement);
                    }

                    if (member != null)
                        properties.Add(member);
                }

            }
            return properties;
        }
    }
}
