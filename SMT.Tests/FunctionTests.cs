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

        public FunctionTests()
        {
            P = new BooleanProblem();
            p = P.DeclareConst("p");
            q = P.DeclareConst("q");
            r = P.DeclareConst("r");
            s = P.DeclareConst("s");
            f = P.DeclareFunc("f");
        }

        [Fact]
        public void CandAnd()
        {
            var f = P.DeclareFunc("f");
            Assert.Equal("(declare-fun f () Bool)", f.ToString());
            Assert.Equal("f and p", P.Assert(f * p).ToString());
        }

    }
}
