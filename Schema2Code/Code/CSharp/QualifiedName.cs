using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Code.CSharp
{
    public class QualifiedName : AbstractQualifiedName
    {
        public override string FullyQualifiedName
        {
            get { return String.Format("{0}.{1}", NameSpace.Name,Name); }
        }
    }
}
