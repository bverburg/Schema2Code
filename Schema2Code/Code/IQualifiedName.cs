using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Code
{
    public interface IQualifiedName : INamed
    {
        INamespace NameSpace { get; set; }
        String FullyQualifiedName { get; }
    }
}
