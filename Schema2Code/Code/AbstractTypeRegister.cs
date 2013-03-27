using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Code
{
    public abstract class AbstractTypeRegister : ITypeRegister
    {
        private readonly List<IType> internalTypes = new List<IType>();

        public IEnumerable<IType> GetTypes(INamespace ns)
        {
            return internalTypes.FindAll(x => x.QualifiedName.NameSpace.Equals(ns));
        }

        public IEnumerable<IType> GetTypes(string ns)
        {
            return internalTypes.FindAll(x => x.QualifiedName.NameSpace.Name.Equals(ns));
        }

        public IType GetType(IQualifiedName qualifiedName)
        {
            return internalTypes.Find(x => x.QualifiedName.Equals(qualifiedName));
        }

        public IType GetType(string qualifiedName)
        {
            return internalTypes.Find(x => x.QualifiedName.FullyQualifiedName.Equals(qualifiedName));
        }

        public void AddType(IType type)
        {
            if(!internalTypes.Contains(type))
                internalTypes.Add(type);
        }

        public void RemoveType(IType type)
        {
            internalTypes.Remove(type);
        }
    }
}
