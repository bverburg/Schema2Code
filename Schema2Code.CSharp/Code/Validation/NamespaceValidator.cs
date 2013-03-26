using System;
using FluentValidation;

namespace Schema2Code.CSharp.Code.Validation
{
    public class NamespaceValidator : AbstractValidator<String>
    {
        public NamespaceValidator()
        {
            RuleFor(ns => ns).NotNull().NotEmpty().Matches("^(([A-Z]{1}[A-Za-z0-9]+)[\\.])+([A-Z]{1}[a-z]+)").OverridePropertyName("Namespace");
        }
    }
}