using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Schema2Code.CSharp.Code;
using Schema2Code.Code;
using Schema2Code.Mapping;
using Schema2Code.Mapping.Formatter;
using Schema2Code.Mapping.Resolver;

namespace Schema2Code.CSharp.Mapping.Resolver
{
    public class NamespaceResolver : AbstractNamespaceResolver
    {
        public static readonly String SchemaNamespace = "http://www.w3.org/2001/XMLSchema";

        IEnumerable<char> CharsToTitleCase(string s)
        {
            bool newWord = true;
            foreach (char c in s)
            {
                if (newWord) { yield return Char.ToUpper(c); newWord = false; }
                else yield return Char.ToLower(c);
                if (c == '.') newWord = true;
            }
        }

        protected override string ResolveCore(string name)
        {
            String ns = String.Empty;

            if (SchemaNamespace.Equals(name))
            {
                return "System";
            }
            else
            {
                //var loc = name.IndexOf(':');

                ns = new string(CharsToTitleCase(name.Replace(':', ',')).ToArray());
            }
            return ns;
        }

        
    }
}
