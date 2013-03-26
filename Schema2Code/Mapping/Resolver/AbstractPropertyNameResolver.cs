using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace Schema2Code.Mapping.Resolver
{
    public abstract class AbstractPropertyNameResolver : ValueResolver<string, string>
    {
        protected abstract override string ResolveCore(string source);
    }
}
