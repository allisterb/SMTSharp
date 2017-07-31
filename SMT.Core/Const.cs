using System;
using System.Reflection;
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
        public Const(string name, Theorem theorem) : base(name, theorem)
        {
            
        }
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

        public override string ToString()
        {
            Expression expr = this;
            string[] t = this.Type.Name.Split('.');
            return string.Format("decl-const {0} {1}", this.Name, t[t.Length - 1]);
        }
        #endregion

        #region Fields
        #endregion


        #region Operators
        public static implicit operator Expression(Const<T> c)
        {
            return (ParameterExpression) c;
        }

        public static explicit operator ParameterExpression(Const<T> c)
        {
            return Expression.Parameter(c.Type, c.Name);
        }

        public static BinaryExpression operator & (Const<T> left, Expression right)
        {
            Type t = typeof(Const<Bool>);
            MethodInfo AndMethod = t.GetRuntimeMethod("DummyAnd2", new[] { typeof(Bool), typeof(Boolean) });
            return Expression.MakeBinary(ExpressionType.And, left, right, false, AndMethod);
        }

        public static BinaryExpression operator & (Expression left, Const<T> right)
        {
            Type t = typeof(Const<Bool>);
            MethodInfo AndMethod = t.GetRuntimeMethod("DummyAnd1", new[] { typeof(Boolean), typeof(Bool) });
            return Expression.MakeBinary(ExpressionType.And, left, right, false, AndMethod);
        }

        public static bool DummyAnd1(Boolean left, Bool right)
        {
            return false;
        }

        public static bool DummyAnd2(Bool left, Boolean right)
        {
            return false;
        }

        public static BinaryExpression operator | (Const<T> left, Expression right)
        {
            return Expression.MakeBinary(ExpressionType.Or, left, right);
        }

        public static BinaryExpression operator | (Expression left, Const<T> right)
        {
            return Expression.MakeBinary(ExpressionType.Or, left, right);
        }

        public static UnaryExpression operator ! (Const<T> c)
        {
            return Expression.MakeUnary(ExpressionType.Not, c, c.Type);
        }

        public static BinaryExpression operator == (Expression left, Const<T> right)
        {
            return Expression.MakeBinary(ExpressionType.Equal, left, right);
        }

        public static BinaryExpression operator == (Const<T> left, Expression right)
        {
            return Expression.MakeBinary(ExpressionType.Equal, left, right);
        }

        public static BinaryExpression operator != (Expression left, Const<T> right)
        {
            return Expression.MakeBinary(ExpressionType.NotEqual, left, right);
        }

        public static BinaryExpression operator != (Const<T> left, Expression right)
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
