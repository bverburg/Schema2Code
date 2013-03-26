using System;
using Schema2Code.Code;

namespace Schema2Code.CSharp.Code
{
    public class QualifiedName : AbstractQualifiedName
    {
        public override string FullyQualifiedName
        {
            get { return String.Format("{0}.{1}", NameSpace.Name, Name); }
        }
    }
}