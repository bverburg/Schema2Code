using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Code
{
    public interface IProperty<TAttribute> : IName, IMetadata<TAttribute> where TAttribute:IAttribute
    {
        IType<TAttribute,IProperty<TAttribute>>  Type { get; set; }
    }
}
