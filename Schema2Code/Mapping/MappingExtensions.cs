using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace Schema2Code.Mapping
{
    public static class MappingExtensions
    {

        //Profile
        public static IMappingExpression<TSource, TDest> IgnoreAllUnmapped<TSource, TDest>(this IMappingExpression<TSource, TDest> expression)
        {
            expression.ForAllMembers(opt => opt.Ignore());
            return expression;
        }

        public static IMappingExpression<TSource, TDest> CreateMapWithLocator<TSource, TDest>(this Profile profile)
        {
            var map = profile.CreateMap<TSource, TDest>();
            map.ConstructUsingServiceLocator();
            return map;
        }
    }


}
