using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace SMT
{
    public class BinaryExpression<T> : Expression<T> where T : Sort
    {
        #region Constructors
        public BinaryExpression(Theorem t, ExpressionType et, Expression<T> term1, Expression<T> term2) : base(t, $"binary_{et}_{term1.Name}_{term2.Name}")
        {
            Term1 = term1;
            Term2 = term2;
            switch (et)
            {
                case ExpressionType.Multiply:
                    if (SortTypeName == "Bool")
                    {
                        et = ExpressionType.And;
                    }
                    break;
                case ExpressionType.Add:
                    if (SortTypeName == "Bool")
                    {
                        et = ExpressionType.Or;
                    }
                    break;
                default:
                    throw new ArgumentException($"Unknown expression type {et}");
            }

            LinqExpression = Expression.MakeBinary(et, term1, term1, false, DummyAndMethod);

        }
        #endregion

        #region Methods
        public static int DummyMul(Expression<T> left, Expression<T> right)
        {
            throw new NotImplementedException();
        }
        /*
        public static bool DummyAnd<E, F>(E left, F right)
        {
            throw new NotImplementedException();
        }
        */
        public static bool DummyAnd(T left, T right)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Properties
        public static Type ClassType { get; } = typeof(BinaryExpression<T>);
        protected static MethodInfo DummyAndMethod { get; } = ClassType.GetRuntimeMethods().First(mi => mi.Name == "DummyAnd");
        public Expression<T> Term1;
        public Expression<T> Term2;
        public ExpressionType ExpressionType;
        #endregion

    }
}
