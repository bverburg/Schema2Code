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
            set { members = new List<IMember>(value);}
        }

        public override string ToString()
        {
            return "Class[ Type = " + base.ToString() + "; Members = " + string.Join(", ", members.Select(x => x.ToString())) + "]";
        }
    }
}