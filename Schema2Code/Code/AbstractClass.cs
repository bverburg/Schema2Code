using System.Collections.Generic;

namespace Schema2Code.Code
{
    public abstract class AbstractClass : AbstractType, IClass
    {
        private readonly List<IProperty> properties = new List<IProperty>();

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

        public override string ToString()
        {
            return "Class: "+base.ToString();
        }
    }
}