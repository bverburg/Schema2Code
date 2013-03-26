using System;
using FluentValidation;
using Ninject;
using Schema2Code.CSharp.Code.Validation;
using Schema2Code.Code;

namespace Schema2Code.CSharp.Code
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