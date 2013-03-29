using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace Schema2Code.Mapping.Formatter
{
    public abstract class AbstractValueFormatter<T> : ValueFormatter<T>, IValueFormatter<T>
    {
        public abstract String Format(T source);

        protected sealed override string FormatValueCore(T value)
        {
            return Format(value);
        }
    }
}
