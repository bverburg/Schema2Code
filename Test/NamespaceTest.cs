using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Schema2Code.CSharp.Code;
using Schema2Code.CSharp.Inject;
using Schema2Code.CSharp.Mapping.Resolver;
using Schema2Code.Code;
using Xunit;

namespace Test
{
    public class NamespaceTest
    {
        [Fact]
        public void TestToString()
        {
            var kernel = new StandardKernel(new CodeModule());
            var name = kernel.Get<IQualifiedName>();
            var nameSpace = kernel.Get<INamespace>();
            
            nameSpace.Name = "bla";

            name.Name = "bla";
            name.NameSpace = nameSpace;
            
           // var name = new QualifiedName {Name = "bla", NameSpace = new Namespace() {Name = "bla"}};
            Assert.Equal("bla.bla", name.FullyQualifiedName);
        }
    }
}
