using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AutoMapper;
using Ninject;

namespace Schema2Code.Mapping
{
    public static class MappingExtensions
    {
        public static void LoadProfiles(this IConfiguration configuration, IKernel kernel, params Assembly[] assemblies)
        {
            var profileType = typeof(Profile);

            if (assemblies == null)
            {
                throw new ArgumentNullException("assemblies");
            }

            foreach (var assembly in assemblies)
            {
                try
                {
                    foreach (var type in assembly.GetTypes())
                    {
                        if (type != profileType && profileType.IsAssignableFrom(type))
                        {
                            configuration.AddProfile((Profile)kernel.Get(type));
                        }
                    }
                }
                catch (ReflectionTypeLoadException)
                {
                    //eat exception, we cant help it if dependencies are broken.
                }
            }

        }

        public static IMappingExpression<TSource, TDest> IgnoreAllUnmapped<TSource, TDest>(this IMappingExpression<TSource, TDest> expression)
        {
            expression.ForAllMembers(opt => opt.Ignore());
            return expression;
        }

        //public static IMappingExpression<TSource, TDest> ValidateUsing<TSource, TDest>(this IMappingExpression<TSource, TDest> mappingExpression, IValidator<TSource> validator)
        //{
        //    return mappingExpression.BeforeMap((x, y) => validator.ValidateAndThrow(x));
        //}

        //public static IMappingExpression<TSource, TDest> ValidateUsing<TSource, TDest>(this IMappingExpression<TSource, TDest> mappingExpression, IValidator<TDest> validator)
        //{
        //    return mappingExpression.AfterMap((x, y) => validator.ValidateAndThrow(y));
        //}
    }


}
