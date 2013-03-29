using System;
using FluentValidation;
using Ninject;
using Schema2Code.CSharp.Code.Validation;
using Schema2Code.Code;

namespace Schema2Code.CSharp.Code
{
    public class Namespace : AbstractNamespace
    {
        private String name;

        [Inject]
        public NamespaceValidator NamespaceValidator { get; set; }

        public override string Name
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