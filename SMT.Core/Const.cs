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
            string[] t = this.SortType.Name.Split('.');
            return string.Format("(decl-const {0} {1})", this.Name, t[t.Length - 1]);
        }
        #endregion

        #region Properties
        protected static Type ClassType { get; } = typeof(Const<T>);
        protected static MethodInfo DummyAnd0Method = ClassType.GetRuntimeMethod("DummyAnd0", new[] { typeof(T), typeof(T) });
        protected static MethodInfo DummyAnd1Method = ClassType.GetRuntimeMethod("DummyAnd1", new[] { typeof(Boolean), typeof(T) });
        protected static MethodInfo DummyAnd2Method = ClassType.GetRuntimeMethod("DummyAnd2", new[] { typeof(T), typeof(Boolean) });
        protected static MethodInfo DummyOr0Method = ClassType.GetRuntimeMethod("DummyOr0", new[] { typeof(T), typeof(T) });
        protected static MethodInfo DummyOr1Method = ClassType.GetRuntimeMethod("DummyOr1", new[] { typeof(Boolean), typeof(T) });
        protected static MethodInfo DummyOr2Method = ClassType.GetRuntimeMethod("DummyOr2", new[] { typeof(T), typeof(Boolean) });
        protected static MethodInfo DummyNotMethod = ClassType.GetRuntimeMethod("DummyNot", new[] { typeof(T) });
        #endregion

        #region Methods
        public static bool DummyAnd1(Boolean left, T right)
        {
            throw new NotImplementedException();
        }

        public static bool DummyAnd2(T left, Boolean right)
        {
            throw new NotImplementedException(); ;
        }

        public static bool DummyOr0(T left, T right)
        {
            throw new NotImplementedException();
        }

        public static bool DummyOr1(Boolean left, T right)
        {
            throw new NotImplementedException();
        }

        public static bool DummyOr2(T left, Boolean right)
        {
            throw new NotImplementedException();
        }

        public static bool DummyNot(T b)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Operators
        public static implicit operator Expression(Const<T> c)
        {
            return (ParameterExpression) c;
        }

        public static explicit operator ParameterExpression(Const<T> c)
        {
            return Expression.Parameter(c.SortType, c.Name);
        }

        public static BinaryExpression operator & (Const<T> left, Const<T> right)
        {
            return Expression.MakeBinary(ExpressionType.And, left, right, false, DummyAnd0Method);
        }

        public static BinaryExpression operator & (Expression left, Const<T> right)
        {
            return Expression.MakeBinary(ExpressionType.And, left, right, false, DummyAnd1Method);
        }

        public static BinaryExpression operator & (Const<T> left, Expression right)
        {
            return Expression.MakeBinary(ExpressionType.And, left, right, false, DummyAnd2Method);
        }

        public static BinaryExpression operator | (Expression left, Const<T> right)
        {
            return Expression.MakeBinary(ExpressionType.Or, left, right, false, DummyOr1Method);
        }

        public static BinaryExpression operator | (Const<T> left, Expression right)
        {
            return Expression.MakeBinary(ExpressionType.And, left, right, false, DummyOr2Method);
        }

        public static UnaryExpression operator ! (Const<T> c)
        {
            return Expression.MakeUnary(ExpressionType.Not, c, c.SortType, DummyNotMethod);
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
