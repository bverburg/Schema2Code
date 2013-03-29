﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using AutoMapper;

namespace Schema2Code.Mapping.Resolver
{
    public abstract class AbstractClassNameResolver : ValueResolver<XmlSchemaElement,String>
    {
    }
}
