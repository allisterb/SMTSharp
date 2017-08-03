using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SMT
{
    public class ConstantExpression<T> : Expression<T> where T : Sort
    {
        public ConstantExpression(Term<T> t) : base(t)
        {
            LinqExpression = Expression.Constant(t, SortType);
        }
    }
}
