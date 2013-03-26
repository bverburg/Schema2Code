using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Code
{
    public abstract class AbstractProperty : IProperty
    {
        private readonly List<IAttribute> attributes = new List<IAttribute>();

        public virtual string Name { get; set; }
        public virtual IType Type { get; set; }
        public virtual IEnumerable<IAttribute> Attributes {
            get { return attributes; }
        }

        public virtual void AddAttribute(IAttribute attribute)
        {
            this.attributes.Add(attribute);
        }
        public virtual void RemoveAttribute(IAttribute attribute)
        {
            this.attributes.Remove(attribute);
        }
    }
}
