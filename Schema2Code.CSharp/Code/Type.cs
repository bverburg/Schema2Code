﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Schema2Code.Code;

namespace Schema2Code.CSharp.Code
{
    public class Type : AbstractType
    {
        public override IQualifiedName QualifiedName { get; set; }
    }
}
