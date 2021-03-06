﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Mapping
{
    public interface IValueResolver<in TFrom, out TTo>
    {
        TTo Resolve(TFrom from);
    }
}
