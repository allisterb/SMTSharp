using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

using SMT;

namespace SMT.Tests
{
    public class ConstTests
    {
        BooleanProblem P;
        Const<Bool> p;
        Const<Bool> q;
        Const<Bool> r;
        Const<Bool> s;

        public ConstTests()
        {
            P = new BooleanProblem();
            
            p = P.DeclareConst("p");
            q = P.DeclareConst("q");
            r = P.DeclareConst("r");
            s = P.DeclareConst("s");
        }
 
        [Fact]
        public void CanDeclareConsts()
        {
            Const<Bool>[] b = P.DeclareConsts("b", 10);
            Assert.NotNull(b);
            Assert.NotEmpty(b);
            Assert.Equal(10, b.Length);
            Assert.Equal("b0", b[0].Name);

        }

        [Fact]
        public void CanConvertToString()
        {
            Const<Bool> b = P.DeclareConst("b");
            Assert.Equal("(decl-const b Bool)", b.ToString());
        }

        [Fact]
        public void CanAnd()
        {
            
            Assert.Equal("(p and q)", P.Assert(p * q).ToString());
            Assert.Equal("(p and (p and p))", P.Assert(p * (p * p)).ToString());
            Assert.Equal("(p and (p and q))", P.Assert(p * (p * q)).ToString());
            Assert.Equal("((p and q) and r)", P.Assert(p * q * r).ToString());
            Assert.Equal("(p and (q and r))", P.Assert(p * (q * r)).ToString());
            Assert.Equal("(p = true)", P.Assert(p == Core.True).ToString());
        }

        [Fact]
        public void CanNot()
        {
            Assert.Equal("(not p)", P.Assert(-p).ToString());
            Assert.Equal("((not p) and q)", P.Assert(-p * q).ToString());
            Assert.Equal("(not (p and q))", P.Assert(-(p * q)).ToString());
        }
    }
}
