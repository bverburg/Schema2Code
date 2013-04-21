using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Code
{
    public abstract class AbstractEnumerableMember : AbstractMember, IEnumerableMember
    {
        public string ItemName { get; set; }

        public override string ToString()
        {
            return Name + " [" + ItemName + ": "+ Type.QualifiedName+"]";
        }
    }
}
