using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Text;

namespace SMT
{
    public class BooleanExpression : Expression<Bool>
    {
        #region Constructors
        protected BooleanExpression(Expression<Bool> e) : base(e)
        {
            LinqExpression = e.LinqExpression;
        }
        #endregion

        #region Operators
        public static implicit operator Formula(BooleanExpression e)
        {
            return new Formula(e);
        }
        public static explicit operator BooleanExpression(ConstantExpression<Bool> e)
        {
            return new BooleanExpression(e);
        }

        public static explicit operator BooleanExpression(BinaryExpression<Bool> e)
        {
            return new BooleanExpression(e);
        }

        public static explicit operator BooleanExpression(UnaryExpression<Bool> e)
        {
            return new BooleanExpression(e);
        }

        public static explicit operator BooleanExpression(Function<Bool> e)
        {
            return new BooleanExpression(e);
        }

        public static explicit operator BooleanExpression(Function<Bool, Bool> e)
        {
            return new BooleanExpression(e);
        }

        public static explicit operator BooleanExpression(Function<Bool, Bool, Bool> e)
        {
            return new BooleanExpression(e);
        }

        public static explicit operator BooleanExpression(Function<Bool, Bool, Bool, Bool> e)
        {
            return new BooleanExpression(e);
        }
        #endregion
    }
}
