using System;
using System.Linq.Expressions;

namespace SMT
{
    /// <summary>
    /// Abstracts an SMT formula constant
    /// </summary>
    /// <typeparam name="T">The sort or type of the constant term</typeparam>
    public class Const<T> : Formula where T : Sort
    {
        #region Constructor
        /// <summary>
        /// Public constructor. Name is required.
        /// </summary>
        /// <param name="name"></param>
        public Const(string name) : base(name) {}
        #endregion

        #region Overriden methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Const<T>)
            {
                Const<T> o = obj as Const<T>;
                return this.Id == o.Id;
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        #endregion

        #region Operators
        public static implicit operator Expression(Const<T> c)
        {
            return Expression.Constant(null, c.Type);
        }

        public static explicit operator ParameterExpression(Const<T> c)
        {
            return Expression.Parameter(c.Type, c.Name);
        }

        public static BinaryExpression operator == (Const<T> left, Const<T> right)
        {
            return Expression.MakeBinary(ExpressionType.Equal, left, right);
        }

        public static BinaryExpression operator != (Const<T> left, Const<T> right)
        {
            return Expression.MakeBinary(ExpressionType.NotEqual, left, right);
        }

        public static BinaryExpression operator < (Const<T> left, Const<T> right)
        {
            return Expression.MakeBinary(ExpressionType.LessThan, left, right);
        }

        public static BinaryExpression operator > (Const<T> left, Const<T> right)
        {
            return Expression.MakeBinary(ExpressionType.GreaterThan, left, right);
        }
        #endregion
    }
}
