﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Code.CSharp
{
    public class Type : AbstractType<Attribute,Property>
    {
        public override IQualifiedName QualifiedName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}
