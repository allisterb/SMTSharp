using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SMT
{
    public class ConstantExpression<T> : Expression<T> where T : Sort
    {
        #region Constructors
        public ConstantExpression(Problem p, string name) : base(p, name)
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
        #endregion
    }
}
