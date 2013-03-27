using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Code
{
    public abstract class AbstractType : IType
    {
        private readonly List<IAttribute> attributes = new List<IAttribute>();
        
        public virtual IQualifiedName QualifiedName { get; set; }

        public virtual IEnumerable<IAttribute> Attributes
        {
            get { return attributes; }
        }

        protected bool Equals(AbstractType other)
        {
            return Equals(QualifiedName, other.QualifiedName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AbstractType) obj);
        }

        public override int GetHashCode()
        {
            return (QualifiedName != null ? QualifiedName.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return "Type: "+ QualifiedName.ToString();
        }
    }
}
