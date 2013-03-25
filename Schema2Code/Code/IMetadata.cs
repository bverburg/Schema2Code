using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Code
{
    public interface IMetadata<T> where T:IAttribute
    {
        IEnumerable<T> Attributes { get; }

        void AddAttribute(T attribute);
        void RemoveAttribute(T attribute);
    }
}
