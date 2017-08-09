using System;
using Xunit;

using SMT;

namespace SMT.Tests
{
    public class FunctionTests
    {
        BooleanProblem P;
        Const<Bool> p;
        Const<Bool> q;
        Const<Bool> r;
        Const<Bool> s;
        Function<Bool> f;
        Function<Bool, Bool> f1;
        Function<Bool, Bool, Bool> f2;
        Function<Bool, Bool, Bool, Bool> f3;

        public FunctionTests()
        {
            P = new BooleanProblem();
            p = P.DeclareConst("p");
            q = P.DeclareConst("q");
            r = P.DeclareConst("r");
            s = P.DeclareConst("s");
            f = P.DeclareFunc("f");
            f1 = P.DeclareFunc<Bool, Bool>("f1");
            f2 = P.DeclareFunc<Bool, Bool, Bool>("f2");
        }

        [Fact]
        public void Arity1FunctionOperators()
        {
            Assert.Equal("f1(p)", P.Assert(f1[p]).ToString());
            Assert.Equal("f1(p and q)", P.Assert(f1[p * q]).ToString());
            Assert.Equal("f1(p and q and r)", P.Assert(f1[p * q * r]).ToString());
        }

        [Fact]
        public void CanConstructArity2()
        {
            var f2l = f2.Lambda();
            Assert.Equal("f2(p q)", P.Assert(f2l(p, q)).ToString());
        }

        [Fact]
        public void CandAnd()
        {
            Assert.Equal("(declare-fun f () Bool)", f.ToString());
            Assert.Equal("(f and p)", P.Assert(f * p).ToString());
            var fl = f1.Lambda();
            Assert.Equal("f1(p)", P.Assert(fl(p)).ToString());
            Assert.Equal("f1(p * q)", P.Assert(fl(p * q)).ToString());
           
        }

    }
}
