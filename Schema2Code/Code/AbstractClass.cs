using System.Collections.Generic;
using System.Linq;

namespace Schema2Code.Code
{
    public abstract class AbstractClass : AbstractType, IClass
    {
        private List<IMember> members = new List<IMember>();
        
        public virtual IEnumerable<IMember> Members
        {
            get { return members; }
            set { members = new List<IMember>(value); }
        }

        public IType Extends { get; set; }

        public override string ToString()
        {
            return QualifiedName.FullyQualifiedName;
        }
    }
}