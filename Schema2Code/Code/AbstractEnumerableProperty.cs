using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Code
{
    public abstract class AbstractEnumerableProperty : AbstractProperty
    {
        public override string ToString()
        {
            return "Enumerable Property: " + Name + "with entry type: " + Type;
        }
    }
}
