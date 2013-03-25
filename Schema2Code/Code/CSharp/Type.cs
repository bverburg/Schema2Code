using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Code.CSharp
{
    public class Type : IType
    {
        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public INamespace NameSpace
        {
            get { throw new NotImplementedException(); }
        }

        public string FullyQualifiedName
        {
            get { throw new NotImplementedException(); }
        }
    }
}
