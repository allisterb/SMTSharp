using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

using SMT;

namespace SMT.Tests
{
    public class ConstTests
    {
        Theorem T;
        Const<Bool> p;
        Const<Bool> q;
        Const<Bool> r;
        Const<Bool> s;

        public ConstTests()
        {
            T = new Theorem();
            p = T.DeclareConst<Bool>("p");
            q = T.DeclareConst<Bool>("q");
            r = T.DeclareConst<Bool>("r");
            s = T.DeclareConst<Bool>("s");
        }
 
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
            
            Assert.Equal("(p and q)", T.Assert(p * q).ToString());
            Assert.Equal("(p and (p and p))", T.Assert(p * (p * p)).ToString());
            Assert.Equal("(p and (p and q))", T.Assert(p * (p * q)).ToString());
        }

        [Fact]
        public void CanNot()
        {
            Assert.Equal("(not p)", T.Assert(-p).ToString());
            Assert.Equal("((not p) and q)", T.Assert(-p * q).ToString());
            Assert.Equal("(not (p and q))", T.Assert(-(p * q)).ToString());
        }
    }
}
