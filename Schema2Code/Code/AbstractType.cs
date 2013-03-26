using System.Collections.Generic;

namespace Schema2Code.Code
{
    public abstract class AbstractType : IType
    {
        private readonly List<IAttribute> attributes = new List<IAttribute>();
        private readonly List<IProperty> properties = new List<IProperty>();

        public virtual IEnumerable<IAttribute> Attributes
        {
            get { return attributes; }
        }

        public virtual void AddAttribute(IAttribute attribute)
        {
            attributes.Add(attribute);
        }

        public virtual void RemoveAttribute(IAttribute attribute)
        {
            attributes.Remove(attribute);
        }

        public abstract IQualifiedName QualifiedName { get; set; }

        public virtual IEnumerable<IProperty> Properties
        {
            get { return properties; }
        }

        public virtual void AddProperty(IProperty property)
        {
            properties.Add(property);
        }

        public virtual void RemoveProperty(IProperty property)
        {
            properties.Remove(property);
        }
    }
}