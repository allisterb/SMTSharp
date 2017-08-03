using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

using SMT;

namespace SMT.Tests
{
    public class ConstTests
    {
        Theorem T = new Theorem();

        [Fact]
        public void CanDeclareConsts()
        {
            Const<Bool>[] b = T.DeclareConsts<Bool>("b", 10);
            Assert.NotNull(b);
            Assert.NotEmpty(b);
            Assert.Equal(10, b.Length);
            Assert.Equal("b0", b[0].Name);

        }

        [Fact]
        public void CanConvertToString()
        {
            Const<Bool> b = T.DeclareConst<Bool>("b");
            Assert.Equal("(decl-const b Bool)", b.ToString());
        }

        [Fact]
        public void CanAnd()
        {
            Const<Bool> p = T.DeclareConst<Bool>("p");
            Const<Bool> q = T.DeclareConst<Bool>("q");
            Assertion a = T.Assert(p * q);
            Assert.Equal("p and q", a.ToString());
            /*
            Assert.Equal("(p and ((not p) and p))", a.ToString());
            a = T.Assert((!p & q) & p);
            Assert.Equal("(((not p) and q) and p)", a.ToString());
            */
        }
    }
}
