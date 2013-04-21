using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Mapping
{
    public interface ITypeConverter<TLeft,TRight>
    {
        TLeft Convert(TRight from);
        TRight Convert(TLeft from);
    }
}
