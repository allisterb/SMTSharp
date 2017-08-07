using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SMT
{
    public class Function<TArg1, TArg2, TReturn> : Expression<TReturn> where TArg1 : Sort where TArg2: Sort where TReturn : Sort
    {
        public Function(Problem solution, string name) : base(solution, name)
        {
            Name = name;
            ConstantExpression<TReturn> r = new ConstantExpression<TReturn>(Solution, Name + "_return");
            ConstantExpression<TArg1> arg1 = new ConstantExpression<TArg1>(Solution, Name + "_arg_1");
            ConstantExpression<TArg1> arg2 = new ConstantExpression<TArg1>(Solution, Name + "_arg_2");
            LinqExpression = Expression.Lambda<Func<TArg1, TArg2, TReturn>>(r, Name, new ParameterExpression[] { (ParameterExpression) arg1, (ParameterExpression) arg2 });
        }

        public override string ToString()
        {
            LambdaExpression e = (LambdaExpression)LinqExpression;
            StringBuilder s = new StringBuilder();
            s.AppendFormat("(declare-fun {0} ({1} {2}) {3})", Name, e.Parameters[0].Type.Name, e.Parameters[1].Type.Name, e.ReturnType.Name);
            return s.ToString();
        }

        #region Properties
        public static Type ClassType { get; } = typeof(Function<TArg1, TArg2, TReturn>);
        public static Type Arg1Type { get; } = typeof(TArg1);
        public static Type Arg2Type { get; } = typeof(TArg1);
        public static Type ReturnType { get; } = typeof(TReturn);
        #endregion
    }
}
