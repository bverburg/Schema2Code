using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using AutoMapper;
using NLog;
using Ninject;
using Schema2Code.Code;

namespace Schema2Code.Mapping.Resolver
{
    public abstract class AbstractTypeResolver : AbstractValueResolver<XmlSchemaElement, IType>
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        [Inject]
        public ITypeRegister TypeRegister { get; set; }
        [Inject]
        public AbstractTypeNameResolver TypeNameResolver { get; set; }

        public override IType Resolve(XmlSchemaElement from)
        {
            var name = TypeNameResolver.Resolve(from);
            var type = TypeRegister.GetType(name);

            if (type == null)
            {
                Logger.Debug("Did not find type, resolving...");
                type = ResolveType(from);
                TypeRegister.AddType(type);
            }
            else
            {
                Logger.Debug("Found already resolved type.");
            }
            return type;
        }
        public abstract IType ResolveType(XmlSchemaElement element);
    }
}
