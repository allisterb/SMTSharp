﻿using System;
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
        internal Expression(Theorem t, string name) : base(t, name) {}
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
            return new UnaryExpression<T>(left.Theorem, ExpressionType.Not, left);
        }

        public static BinaryExpression<T> operator +(Expression<T> left, Expression<T> right)
        {
            return new BinaryExpression<T>(left.Theorem, ExpressionType.Add, left, right); ;
        }

        public static BinaryExpression<T> operator *(Expression<T> left, Expression<T> right)
        {
            return new BinaryExpression<T>(left.Theorem, ExpressionType.Multiply, left, right); ;
        }
        #endregion
    }
}
