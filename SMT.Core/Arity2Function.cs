using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SMT
{
    public class Function<TArg1, TArg2, TReturn> : Expression<TReturn> where TArg1 : Sort where TArg2: Sort where TReturn : Sort
    {
        #region Constructors
        public Function(Theory theory, string name) : base(theory, name)
        {
            Return = new ConstantExpression<TReturn>(Theory, Name + "_return");
            Arg1 = new ConstantExpression<TArg1>(Theory, Name + "_arg_1");
            Arg2 = new ConstantExpression<TArg2>(Theory, Name + "_arg_2");
            LinqExpression = Expression.Lambda(Return, Name, new ParameterExpression[] { (ParameterExpression) Arg1, (ParameterExpression) Arg2 });
        }
        #endregion

        #region Overriden methods
        public override string ToString()
        {
            LambdaExpression e = (LambdaExpression)LinqExpression;
            StringBuilder s = new StringBuilder();
            s.AppendFormat("(declare-fun {0} ({1} {2}) {3})", Name, e.Parameters[0].Type.Name, e.Parameters[1].Type.Name, e.ReturnType.Name);
            return s.ToString();
        }
        #endregion

        #region Properties
        public static Type ClassType { get; } = typeof(Function<TArg1, TArg2, TReturn>);
        public static Type Arg1Type { get; } = typeof(TArg1);
        public static Type Arg2Type { get; } = typeof(TArg2);
        public static Type ReturnType { get; } = typeof(TReturn);
        public ConstantExpression<TReturn> Return { get; set; }
        public Expression<TArg1> Arg1 { get; set; }
        public Expression<TArg2> Arg2 { get; set; }
        public Function<TArg1, TArg2, TReturn> this[Tuple<Expression<TArg1>, Expression<TArg2>> arg]
        {
            get
            {
                Arg1 = arg.Item1;
                Arg2 = arg.Item2;
                LinqExpression = Expression.Lambda(Return, Name, new ParameterExpression[] { (ParameterExpression)Arg1, (ParameterExpression)Arg2 });
                return this;
            }
        }
        #endregion

        #region Methods
        public Function<TArg1, TArg2, TReturn> _(Tuple<Expression<TArg1>, Expression<TArg2>> arg)
        {
            return this[arg];
        }

        public Func<Expression<TArg1>, Expression<TArg2>, Function<TArg1, TArg2, TReturn>> Lambda()
        {
            return new Func<Expression<TArg1>, Expression<TArg2>, Function<TArg1, TArg2, TReturn>>((p, q) => this[new Tuple<Expression<TArg1>, Expression<TArg2>>(p, q)]);
        }
        #endregion
    }
}
