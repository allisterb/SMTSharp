using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SMT
{
    public class UnaryExpression<T> : Expression<T> where T : Sort
    {
        #region Constructors
        public UnaryExpression(Theorem t, ExpressionType et, Term<T> term1) : base(t, $"unary_{et}_{term1.Name}")
        {
            Term1 = term1;
            LinqExpression = Expression.MakeUnary(et, Expression.Parameter(SortType, Term1.Name), SortType);
        }
        #endregion

        #region Properties
        public static Type ClassType { get; } = typeof(UnaryExpression<T>);
        public Term<T> Term1;
        #endregion
    }
}
