using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace SMT
{
    public class UnaryExpression<T> : Expression<T> where T : Sort
    {
        #region Constructors
        public UnaryExpression(Problem t, ExpressionType et, Expression<T> term1) : base(t, $"unary_{et}_{term1.Name}")
        {
            Term1 = term1;
            switch (et)
            {
                case ExpressionType.Not:
                    LinqExpression = Expression.MakeUnary(et, Term1, Term1.LinqExpression.Type, GetDummyNotMethod(Term1.LinqExpression.Type));
                    break;
                default:
                    throw new ArgumentException($"The expression type {et} is not supported as a unary expression.");
            }
            
        }
        #endregion

        #region Properties
        public static Type ClassType { get; } = typeof(UnaryExpression<T>);
        protected static MethodInfo GenericDummyNotMethod { get; } = ClassType.GetRuntimeMethods().First(mi => mi.Name == "GenericDummyNot");
        public Expression<T> Term1;
        #endregion

        #region Methods
        public static bool GenericDummyNot<E>(E left)
        {
            throw new NotImplementedException();
        }

        public static MethodInfo GetDummyNotMethod(Type e)
        {
            return GenericDummyNotMethod.MakeGenericMethod(e);
        }
        #endregion
    }
}
