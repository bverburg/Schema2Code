using Ninject.Modules;
using Schema2Code.CSharp.Code;
using Schema2Code.CSharp.Code.Validation;
using Schema2Code.CSharp.Mapping.Formatter;
using Schema2Code.CSharp.Mapping.Resolver;
using Schema2Code.Code;
using Schema2Code.Mapping;
using Schema2Code.Mapping.Formatter;
using Schema2Code.Mapping.Resolver;

namespace Schema2Code.CSharp.Inject
{
    public class CSharpModule : NinjectModule
    {
        public override void Load()
        {
            Bind<NamespaceValidator>().ToSelf();
            Bind<AbstractNamespaceResolver>().To<NamespaceResolver>();
           // Bind<AbstractClassNameResolver>().To<NamespaceResolver>();
            Bind<AbstractMembersResolver>().To<MembersResolver>();
            Bind<AbstractTypeNameFormatter>().To<TypeNameFormatter>();
            Bind<AbstractMemberNameFormatter>().To<MemberNameFormatter>();
            Bind<AbstractEnumerableTypeResolver>().To<EnumerableTypeResolver>();
            Bind<AbstractEnumerableItemNameResolver>().To<EnumerableItemNameResolver>();
            Bind<AbstractTypeResolver>().To<TypeResolver>();
            Bind<IAttribute>().To<Attribute>();
            Bind<IEnumerableMember>().To<EnumerableMember>();
            Bind<IMember>().To<Member>();
            Bind<INamespace>().To<Namespace>();
            Bind<IClass>().To<Class>();
            Bind<IType>().To<Type>();
            Bind<IQualifiedName>().To<QualifiedName>();
        }
    }
}