using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Code
{
    public abstract class AbstractEnumEntry : IEnumEntry
    {
        public string Name { get; set; }
    }
}
