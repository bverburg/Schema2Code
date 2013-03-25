using System.Collections.Generic;
using System.Linq;
using System.Text;
using Schema2Code.Code.CSharp;
using Attribute = System.Attribute;

namespace Schema2Code.Code
{
    public abstract class AbstractType<TAttribute,TProperty> : IType<TAttribute,TProperty> where TAttribute : IAttribute where TProperty:IProperty<TAttribute>
    {
        private readonly List<TAttribute> attributes = new List<TAttribute>();
        private readonly List<TProperty> properties = new List<TProperty>();

        public virtual IEnumerable<TAttribute> Attributes {
            get { return attributes;  }
        }
        public virtual void AddAttribute(TAttribute attribute)
        {
            attributes.Add(attribute);
        }

        public virtual void RemoveAttribute(TAttribute attribute)
        {
            attributes.Remove(attribute);
        }

        public abstract IQualifiedName QualifiedName { get; set; }

        public virtual IEnumerable<TProperty> Properties
        {
            get { return properties; }
        }
        public virtual void AddProperty(TProperty property)
        {
            properties.Add(property);
        }
        public virtual void RemoveProperty(TProperty property)
        {
            properties.Remove(property);
        }
    }
}
