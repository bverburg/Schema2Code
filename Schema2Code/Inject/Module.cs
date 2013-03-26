using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Schema2Code.Code.CSharp.Validation;

namespace Schema2Code.Inject
{
    public class Module : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<NamespaceValidator>().ToSelf();
        }
    }
}
