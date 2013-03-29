using System.Collections.Generic;
using Ninject.Modules;
using Schema2Code.CSharp.Code;
using Schema2Code.CSharp.Code.Validation;
using Schema2Code.CSharp.Mapping.Formatter;
using Schema2Code.CSharp.Mapping.Resolver;
using Schema2Code.Code;
using Schema2Code.Mapping.Formatter;
using Schema2Code.Mapping.Resolver;

namespace Schema2Code.CSharp.Inject
{
    public class CSharpModule : NinjectModule
    {
        public override void Load()
        {
            Bind<NamespaceValidator>().ToSelf().InSingletonScope();
            Bind<AbstractNamespaceResolver>().To<NamespaceResolver>().InSingletonScope();
            Bind<AbstractTypeNameResolver>().To<TypeNameResolver>().InSingletonScope();
            Bind<AbstractMembersResolver>().To<MembersResolver>().InSingletonScope();
            Bind<AbstractTypeNameFormatter>().To<TypeNameFormatter>().InSingletonScope();
            Bind<AbstractMemberNameFormatter>().To<MemberNameFormatter>().InSingletonScope();
            Bind<AbstractEnumerableTypeResolver>().To<EnumerableTypeResolver>().InSingletonScope();
            Bind<AbstractEnumerableItemNameResolver>().To<EnumerableItemNameResolver>().InSingletonScope();
            Bind<AbstractTypeResolver>().To<TypeResolver>().InSingletonScope();
            Bind<IAttribute>().To<Attribute>();
            Bind<IEnumerableMember>().To<EnumerableMember>();
            Bind<IMember>().To<Member>();
            Bind<INamespace>().To<Namespace>();
            Bind<IClass>().To<Class>();
            Bind<IType>().To<Type>();
            Bind<IQualifiedName>().To<QualifiedName>();
            Bind<ITypeRegister>().To<TypeRegister>().InSingletonScope();
        }
    }
}