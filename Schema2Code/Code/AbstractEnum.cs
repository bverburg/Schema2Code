using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Code
{
    public abstract class AbstractEnum : AbstractType, IEnum
    {
        public virtual IEnumerable<IEnumEntry> Entries { get; set; }

        public override string ToString()
        {
            return "Enum[ Name = " + QualifiedName + "; ]";
        }
    }
}
