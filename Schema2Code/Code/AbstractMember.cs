using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Code
{
    public abstract class AbstractMember : IMember
    {
        private readonly List<IAttribute> attributes = new List<IAttribute>();

        public virtual string Name { get; set; }

        public virtual IType Type { get; set; }

        public virtual bool IsNullable { get; set; }

        public virtual bool IsRequired { get; set; }

        public virtual IEnumerable<IAttribute> Attributes
        {
            get { return attributes; }
        }

        protected bool Equals(AbstractMember other)
        {
            return string.Equals(Name, other.Name) && Equals(Type, other.Type);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AbstractMember)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (Type != null ? Type.GetHashCode() : 0);
            }
        }

        public override string ToString()
        {
            return Name + ": " + Type.QualifiedName;
        }
    }
}
