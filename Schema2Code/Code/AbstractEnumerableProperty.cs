using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Code
{
    public abstract class AbstractEnumerableProperty : AbstractProperty, IEnumerableProperty
    {
        public string ItemName { get; set; }

        public override string ToString()
        {
            return "Enumerable Property[ Name = " + Name + "; ItemName = " + ItemName + " Type = "+ Type +"]";
        }
    }
}
