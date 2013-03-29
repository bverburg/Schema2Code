using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Code
{
    public abstract class AbstractQualifiedName : IQualifiedName
    {
        public virtual string Name { get; set; }
        public virtual INamespace NameSpace { get; set; }
        public abstract string FullyQualifiedName { get; }

        public override string ToString()
        {
            return FullyQualifiedName;
        }

        protected bool Equals(AbstractQualifiedName other)
        {
            return string.Equals(Name, other.Name) && Equals(NameSpace, other.NameSpace);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AbstractQualifiedName) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0)*397) ^ (NameSpace != null ? NameSpace.GetHashCode() : 0);
            }
        }

        public static implicit operator String(AbstractQualifiedName name)
        {
            return name.FullyQualifiedName;
        }
    }
}
