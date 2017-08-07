using System;
using System.Collections.Generic;
using System.Text;

namespace SMT
{
    public abstract class Theory
    {
        public Assertion Assert(ConstantExpression<Bool> b)
        {
            Assertion a = new Assertion((BooleanExpression)b);
            Append(a);
            return a;
        }

        public Assertion Assert(UnaryExpression<Bool> b)
        {
            Assertion a = new Assertion((BooleanExpression)b);
            Append(a);
            return a;
        }

        public Assertion Assert(BinaryExpression<Bool> b)
        {
            Assertion a = new Assertion((BooleanExpression)b);
            Append(a);
            return a;
        }

        protected void Append(ITerm t)
        {
            Terms.Enqueue(t);
        }
        #region Properties
        protected Queue<ITerm> Terms = new Queue<ITerm>();
        #endregion

    }

    

}
