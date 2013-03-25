using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Code
{
    public abstract class AbstractQualifiedName : IQualifiedName
    {
        public virtual string Name { get; set; }
        public virtual INamespace NameSpace { get; set; }
        public abstract string FullyQualifiedName { get; }
    }
}
