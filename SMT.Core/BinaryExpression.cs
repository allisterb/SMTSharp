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
                        LinqExpression = Expression.MakeBinary(ExpressionType.And, term1, term2, false, GetDummyAndMethod(term1.LinqExpression.Type, term2.LinqExpression.Type));
                    }
                    else
                    {
                        LinqExpression = Expression.MakeBinary(ExpressionType.Multiply, term2, term1, false, GetDummyMulMethod(term1.LinqExpression.Type, term2.LinqExpression.Type));
                    }
                    break;
                case ExpressionType.Add:
                    if (SortTypeName == "Bool")
                    {
                        LinqExpression = Expression.MakeBinary(ExpressionType.Or, term1, term2, false, GetDummyOrMethod(term1.LinqExpression.Type, term2.LinqExpression.Type));
                    }
                    else
                    {
                        LinqExpression = Expression.MakeBinary(ExpressionType.Add, term1, term2, false, GetDummyAddMethod(term1.LinqExpression.Type, term2.LinqExpression.Type));
                    }
                    break;
                default:
                    throw new ArgumentException($"Unknown expression type {et}");
            }

            

        }
        #endregion

        #region Methods
        public static bool GenericDummyAnd<E, F>(E left, F right)
        {
            throw new NotImplementedException();
        }

        public static int GenericDummyMul<E, F>(E left, F right)
        {
            throw new NotImplementedException();
        }

  

        public static int GenericDummyAdd<E, F>(E left, F right)
        {
            throw new NotImplementedException();
        }

        public static bool GenericDummyOr<E, F>(E left, F right)
        {
            throw new NotImplementedException();
        }


        public static MethodInfo GetDummyMulMethod(Type e, Type f)
        {
            return GenericDummyMulMethod.MakeGenericMethod(e, f);
        }

        public static MethodInfo GetDummyAndMethod(Type e, Type f)
        {
            return GenericDummyAndMethod.MakeGenericMethod(e, f);
        }

        public static MethodInfo GetDummyAddMethod(Type e, Type f)
        {
            return GenericDummyAddMethod.MakeGenericMethod(e, f);
        }

        public static MethodInfo GetDummyOrMethod(Type e, Type f)
        {
            return GenericDummyOrMethod.MakeGenericMethod(e, f);
        }


        /*
        public static bool DummyAndMethod2(Expression l, Expression right)
        {
            throw new NotImplementedException();
        }

  

        public static int DummyMul(T left, T right)
        {
            throw new NotImplementedException();
        }

        public static bool DummyAnd(T left, T right)
        {
            throw new NotImplementedException();
        }

        public static int DummyAdd(T left, T right)
        {
            throw new NotImplementedException();
        }

        public static bool DummyOr(T left, T right)
        {
            throw new NotImplementedException();
        }
        */

        #endregion

        #region Properties
        public static Type ClassType { get; } = typeof(BinaryExpression<T>);
        protected static MethodInfo GenericDummyAndMethod { get; } = ClassType.GetRuntimeMethods().First(mi => mi.Name == "GenericDummyAnd");
        protected static MethodInfo GenericDummyMulMethod { get; } = ClassType.GetRuntimeMethods().First(mi => mi.Name == "GenericDummyMul");
        protected static MethodInfo GenericDummyOrMethod { get; } = ClassType.GetRuntimeMethods().First(mi => mi.Name == "GenericDummyOr");
        protected static MethodInfo GenericDummyAddMethod { get; } = ClassType.GetRuntimeMethods().First(mi => mi.Name == "GenericDummyAdd");
        public Expression<T> Term1;
        public Expression<T> Term2;
        public ExpressionType ExpressionType;
        #endregion

    }
}
