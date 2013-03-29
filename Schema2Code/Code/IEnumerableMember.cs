using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Code
{
    public interface IEnumerableMember : IMember
    {
        String ItemName { get; set; }
    }
}
