using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SMT
{
    public class ConstantExpression<T> : Expression<T> where T : Sort
    {
        #region Constructors
        public ConstantExpression(Theory t, string name) : base(t, name)
        {
            LinqExpression = Expression.Parameter(SortType, this.Name);
        }
        #endregion

        #region Properties
        public static Type ClassType { get; } = typeof(ConstantExpression<T>);
        #endregion

        #region Operators
        public static explicit operator ParameterExpression(ConstantExpression<T> c)
        {
            return (ParameterExpression)c.LinqExpression;
        }

        public static Function<T> operator *(Func<Function<T>> f, ConstantExpression<T> arg)
        {
            return f.Invoke();
        }
        #endregion
    }
}
