using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Code
{
    public interface ITypeRegister
    {
        IEnumerable<IType> GetTypes(INamespace ns);
        IEnumerable<IType> GetTypes(String ns);
        IType GetType(IQualifiedName qualifiedName);
        IType GetType(String qualifiedName);

        void AddType(IType type);
        void RemoveType(IType type);
    }
}
