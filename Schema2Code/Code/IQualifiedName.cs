using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Code
{
    public interface IQualifiedName
    {
        String Name { get; }
        INamespace NameSpace { get; }
        String FullyQualifiedName { get; }
    }
}
