using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Mapping
{
    public class DelegatingTypeConverter<TLeft,TRight> : ITypeConverter<TLeft,TRight>
    {
        private readonly IValueResolver<TLeft, TRight> leftToRight;
        private readonly IValueResolver<TRight, TLeft> rightToLeft;

        public DelegatingTypeConverter(IValueResolver<TLeft, TRight> leftToRight,
                                       IValueResolver<TRight, TLeft> rightToLeft)
        {
            this.leftToRight = leftToRight;
            this.rightToLeft = rightToLeft;
        }

        public TLeft Convert(TRight @from)
        {
            return rightToLeft.Resolve(from);
        }

        public TRight Convert(TLeft @from)
        {
            return leftToRight.Resolve(from);
        }
    }
}
