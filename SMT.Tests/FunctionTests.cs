using System;
using Xunit;

using SMT;

namespace SMT.Tests
{
    public class FunctionTests
    {
        Theorem T = new Theorem();

        [Fact]
        public void Test1()
        {
            var f = T.DeclareFunc<Bool, Bool, Bool>("f");
        }
    }
}
