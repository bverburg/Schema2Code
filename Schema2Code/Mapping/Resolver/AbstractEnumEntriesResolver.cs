using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using Schema2Code.Code;

namespace Schema2Code.Mapping.Resolver
{
    public abstract class AbstractEnumEntriesResolver : AbstractValueResolver<XmlSchemaSimpleTypeRestriction, List<IEnumEntry>>
    {

    }
}
