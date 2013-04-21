using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using AutoMapper;
using NLog;
using Ninject;
using Schema2Code.Code;
using Schema2Code.Xml.Schema.Extension;

namespace Schema2Code.Mapping.Resolver
{
    public abstract class AbstractTypeResolver : AbstractValueResolver<XmlSchemaElement, IType>
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        protected ITypeRegister TypeRegister { get; set; }
        protected IMappingEngine MappingEngine { get; set; }
        protected AbstractTypeNameResolver TypeNameResolver { get; set; }

        protected AbstractTypeResolver(ITypeRegister typeRegister, AbstractTypeNameResolver typeNameResolver, IMappingEngine mappingEngine)
        {
            this.TypeRegister = typeRegister;
            this.TypeNameResolver = typeNameResolver;
            this.MappingEngine = mappingEngine;
        }

        public override IType Resolve(XmlSchemaElement from)
        {
            var name = TypeNameResolver.Resolve(from);
            var type = TypeRegister.GetType(name);

            if (type == null)
            {
                Logger.Debug("Did not find type, resolving...");
                type = ResolveType(from);
                if(type == null)
                    throw new ApplicationException("Could not resolve type "+from.Name);
                TypeRegister.AddType(type);
            }
            else
            {
                Logger.Debug("Found already resolved type.");
            }
            return type;
        }

        public virtual IType ResolveType(XmlSchemaElement source)
        {
            if (source.IsComplexType())
            {
                return MappingEngine.Map<IClass>(source);
            }
            if (source.IsSimpleType())
            {

                var elementType = (XmlSchemaSimpleTypeRestriction)((XmlSchemaSimpleType)source.ElementSchemaType).Content;
                if (elementType.Facets.Count > 0)
                {

                }
                return MappingEngine.Map<IType>(source);
            }
            return null;
        }
    }
}
