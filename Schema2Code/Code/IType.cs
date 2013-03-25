using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Code
{
    public interface IType<TAttribute,TProperty> : IMetadata<TAttribute> where TAttribute:IAttribute where TProperty:IProperty<TAttribute>
    {
        IQualifiedName QualifiedName { get; set; }
        IEnumerable<TProperty> Properties { get; }

        void AddProperty(TProperty property);
        void RemoveProperty(TProperty property);
    }
}
