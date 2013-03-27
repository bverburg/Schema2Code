using System;
using FluentValidation;

namespace Schema2Code.CSharp.Code.Validation
{
    public class NamespaceValidator : AbstractValidator<String>
    {
        public NamespaceValidator()
        {
            RuleFor(ns => ns).NotNull().NotEmpty().Matches("^(([A-Za-z0-9]+)[\\.]{0,1})+([A-Za-z]+)").OverridePropertyName("Namespace");
        }
    }
}