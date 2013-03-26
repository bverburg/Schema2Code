using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using Ninject;
using Schema2Code.Code.CSharp.Validation;

namespace Schema2Code.Code.CSharp
{
    public class Namespace : INamespace
    {
        private String name;

        [Inject]
        public NamespaceValidator NamespaceValidator { get; set; }

        public string Name
        {
            get { return name; }
            set
            {
                NamespaceValidator.ValidateAndThrow(value);
                name = value;
            }
        }
    }
}
