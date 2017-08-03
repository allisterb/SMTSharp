using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SMT
{
    public class ConstantExpression<T> : Expression<T> where T : Sort
    {
        #region Constructors
        public ConstantExpression(Theorem t, string name) : base(t, name)
        {
            LinqExpression = Expression.Constant(null, SortType);
        }
        #endregion

        #region Properties
        public static Type ClassType { get; } = typeof(ConstantExpression<T>);
        #endregion
    }
}
