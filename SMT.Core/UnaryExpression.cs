using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SMT
{
    public class UnaryExpression<T> : Expression<T> where T : Sort
    {
        public UnaryExpression(Theorem t, ExpressionType et, Term<T> term1) : base(t)
        {
            Term1 = term1;
            LinqExpression = Expression.MakeUnary(et, Expression.Parameter(SortType, Term1.Id), SortType);
        }

        public Term<T> Term1;
    }
}
