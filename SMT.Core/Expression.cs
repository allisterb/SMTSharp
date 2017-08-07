using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace SMT
{
    public abstract class Expression<T> : Term<T> where T : Sort
    {
        #region Constructors
        internal Expression(Term<T> t) : base(t) {}
        internal Expression(Theory t, string name) : base(t, name) {}
        #endregion

        #region Overriden methods
        public override bool Equals(object obj)
        {
            if (obj is Expression<T>)
            {
                Expression<T> e = obj as Expression<T>;
                return (e.Id == this.Id);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        #endregion

        #region Properties
        internal Expression LinqExpression;
        #endregion

        #region Operators
        public static implicit operator Expression(Expression<T> e)
        {
            return e.LinqExpression;
        }
        public static UnaryExpression<T> operator - (Expression<T> left)
        {
            return new UnaryExpression<T>(left.Theory, ExpressionType.Not, left);
        }

        public static BinaryExpression<T> operator +(Expression<T> left, Expression<T> right)
        {
            return new BinaryExpression<T>(left.Theory, ExpressionType.Add, left, right); ;
        }

        public static BinaryExpression<T> operator *(Expression<T> left, Expression<T> right)
        {
            return new BinaryExpression<T>(left.Theory, ExpressionType.Multiply, left, right); ;
        }

        public static BinaryExpression<T> operator ==(Expression<T> left, Expression<T> right)
        {
            return new BinaryExpression<T>(left.Theory, ExpressionType.Equal, left, right); ;
        }

        public static BinaryExpression<T> operator !=(Expression<T> left, Expression<T> right)
        {
            return new BinaryExpression<T>(left.Theory, ExpressionType.NotEqual, left, right); ;
        }
        #endregion
    }
}
