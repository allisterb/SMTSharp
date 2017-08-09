using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SMT
{
    public class Function<TArg1, TArg2, TArg3, TReturn> : Expression<TReturn> where TArg1 : Sort where TArg2 : Sort where TArg3 : Sort where TReturn : Sort
    {
        #region Constructors
        public Function(Theory theory, string name) : base(theory, name)
        {
            Return = new ConstantExpression<TReturn>(Theory, Name);
            Arg1 = new ConstantExpression<TArg1>(Theory, Name + "_arg_1");
            Arg2 = new ConstantExpression<TArg2>(Theory, Name + "_arg_2");
            Arg3 = new ConstantExpression<TArg3>(Theory, Name + "_arg_3");
            LinqExpression = Expression.Lambda(Return, Name, new ParameterExpression[] { (ParameterExpression)Arg1, (ParameterExpression)Arg2, (ParameterExpression)Arg3 });
        }
        #endregion

        #region Overriden methods
        public override string ToString()
        {
            LambdaExpression e = (LambdaExpression) this.LinqExpression;
            StringBuilder s = new StringBuilder();
            s.AppendFormat("declare-fun {0} ({1}) {2} {3}) {4}", e.Name, e.Parameters[0].Type.Name, e.Parameters[1].Type.Name, e.Parameters[2].Type.Name, e.ReturnType.Name);
            return s.ToString();
        }
        #endregion

        #region Properties
        public static Type ClassType { get; } = typeof(Function<TArg1, TArg2, TReturn>);
        public static Type Arg1Type { get; } = typeof(TArg1);
        public static Type Arg2Type { get; } = typeof(TArg2);
        public static Type Arg3Type { get; } = typeof(TArg3);
        public static Type ReturnType { get; } = typeof(TReturn);
        public ConstantExpression<TReturn> Return { get; set; }
        public Expression<TArg1> Arg1 { get; set; }
        public Expression<TArg2> Arg2 { get; set; }
        public Expression<TArg3> Arg3 { get; set; }
        public Function<TArg1, TArg2, TArg3, TReturn> this[Tuple<Expression<TArg1>, Expression<TArg2>, Expression<TArg3>> arg]
        {
            get
            {
                Arg1 = arg.Item1;
                Arg2 = arg.Item2;
                Arg3 = arg.Item3;
                return this;
            }
        }
        #endregion

        #region Methods
        public Function<TArg1, TArg2, TArg3, TReturn> _(Tuple<Expression<TArg1>, Expression<TArg2>, Expression<TArg3>> arg)
        {
            return this[arg];
        }

        public Func<Function<TArg1, TArg2, TArg3, TReturn>> Lambda()
        {
            return new Func<Function<TArg1, TArg2, TArg3, TReturn>>(() => this);
        }
        #endregion

        #region Operators
        public static Function<TArg1, TArg2, TArg3, TReturn> operator *(Function<TArg1, TArg2, TArg3, TReturn> f, Tuple<Expression<TArg1>, Expression<TArg2>, Expression<TArg3>> arg)
        {
            return f[arg];
        }
        #endregion
    }
}
