using System.Collections.Generic;
using System.Linq;

namespace Schema2Code.Code
{
    public abstract class AbstractClass : AbstractType, IClass
    {
        private List<IProperty> properties = new List<IProperty>();

        public virtual IEnumerable<IProperty> Properties
        {
            get { return properties; }
            set { properties = new List<IProperty>(value);}
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
            return "Class[ Type = " + base.ToString() + "; Properties = " + string.Join(", ", properties.Select(x => x.ToString())) + "]";
        }
    }
}