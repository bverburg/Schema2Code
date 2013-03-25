using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema2Code.Code.CSharp
{
    public class Namespace : INamespace
    {
        private String name;

        public string Name
        {
            get { return name; }
            set
            {
                if (Validate(value))
                {
                    name = value;
                }
            }
        }

        public static bool Validate(String name)
        {
            return true;
        }
    }
}
