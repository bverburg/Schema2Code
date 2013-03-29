using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Code
{
    public abstract class AbstractNamespace : INamespace
    {
        public virtual String Name { get; set; }

        protected bool Equals(AbstractNamespace other)
        {
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AbstractNamespace) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}
