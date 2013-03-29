using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Code
{
    public interface IClass : IType
    {
        IEnumerable<IMember> Members { get; set; }
    }
}
