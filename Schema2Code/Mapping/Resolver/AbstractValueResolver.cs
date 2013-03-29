using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace Schema2Code.Mapping.Resolver
{
    public abstract class AbstractValueResolver<TSource, TDestination> : ValueResolver<TSource, TDestination>, IValueResolver<TSource, TDestination>
    {
        protected override TDestination ResolveCore(TSource source)
        {
            return Resolve(source);
        }

        public abstract TDestination Resolve(TSource from);
    }
}
