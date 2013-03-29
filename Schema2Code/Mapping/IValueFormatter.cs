using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Mapping
{
    public interface IValueFormatter<in T>
    {
        String Format(T source);
    }
}
