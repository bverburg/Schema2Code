using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Syntax;

namespace Schema2Code.Inject
{
    public static class NinjectExtensions
    {
        public static BoundToSyntax<T> ToBound<T>(this IBindingToSyntax<T> bindingToSyntax)
        {
            return new BoundToSyntax<T>(bindingToSyntax);
        }
    }
    public class BoundToSyntax<T>
    {
        private readonly IBindingToSyntax<T> bindingToSyntax;

        internal BoundToSyntax(IBindingToSyntax<T> bindingToSyntax)
        {
            this.bindingToSyntax = bindingToSyntax;
        }

        public IBindingWhenInNamedWithOrOnSyntax<TF> Get<TF>() where TF : T
        {
            return bindingToSyntax.ToMethod(ctx => ctx.Kernel.Get<TF>());
        }
    }
}
