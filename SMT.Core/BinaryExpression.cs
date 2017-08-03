using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace SMT
{
    public class BinaryExpression<T> : Expression<T> where T : Sort
    {
        public BinaryExpression(Theorem t, ExpressionType et, Term<T> term1, Term<T> term2) : base(t)
        {
            Term1 = term1;
            Term2 = term2;
            LinqExpression = Expression.MakeBinary(et, Expression.Parameter(SortType, term1.Id), Expression.Parameter(SortType, term2.Id), false, DummyMulMethod);

        }
        #region Methods
        public static int DummyMul(T left, T right)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Properties
        public static new Type ClassType { get; } = typeof(BinaryExpression<T>);
        protected static MethodInfo DummyMulMethod = ClassType.GetRuntimeMethod("DummyMul", new[] { typeof(T), typeof(T) });
        #endregion

        public Term<T> Term1;
        public Term<T> Term2;
        public ExpressionType ExpressionType;


    }
}
