using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Code
{
    public interface IType : IMetadata 
    {
        IQualifiedName QualifiedName { get; set; }
        IEnumerable<IProperty> Properties { get; }
    }
}
