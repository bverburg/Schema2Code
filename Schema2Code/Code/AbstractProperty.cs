using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Code
{
    public abstract class AbstractProperty<TAttribute> : IProperty<TAttribute> where TAttribute:IAttribute
    {
        private List<TAttribute> attributes = new List<TAttribute>();

        public virtual string Name { get; set; }
        public virtual IType<TAttribute, IProperty<TAttribute>> Type { get; set; }
        public virtual IEnumerable<TAttribute> Attributes {
            get { return attributes; }
        }

        public virtual void AddAttribute(TAttribute attribute)
        {
            this.attributes.Add(attribute);
        }
        public virtual void RemoveAttribute(TAttribute attribute)
        {
            this.attributes.Remove(attribute);
        }
        
    }
}
