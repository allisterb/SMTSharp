using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SMT
{
    public class Function<TArg1, TReturn> : Expression<TReturn> where TArg1 : Sort where TReturn : Sort
    {
        #region Constructors
        internal Function(Theory theory, string name) : base(theory, name)
        {
            Return = new ConstantExpression<TReturn>(Theory, Name);
            Arg1 = new ConstantExpression<TArg1>(Theory, Name + "_arg_1");
            LinqExpression = Expression.Lambda(Return, Name, new ParameterExpression[] { (ParameterExpression) Arg1 });
        }
        #endregion
        
        #region Overriden methods
        public override string ToString()
        {
            LambdaExpression e = (LambdaExpression)LinqExpression;
            StringBuilder s = new StringBuilder();
            s.AppendFormat("(declare-fun {0} ({1}) {2})", Name, e.Parameters[0].Type.Name, e.ReturnType.Name);
            return s.ToString();
        }
        #endregion

        #region Properties
        public static Type ClassType { get; } = typeof(Function<TArg1, TReturn>);
        public static Type Arg1Type { get; } = typeof(TArg1);
        public static Type ReturnType { get; } = typeof(TReturn);
        public ConstantExpression<TReturn> Return { get; set; }
        protected Expression<TArg1> Arg1 { get; set; }
        public Function<TArg1, TReturn> this[Expression<TArg1> arg]
        {
            get
            {
                Arg1 = arg;
                LinqExpression = Expression.Lambda(Return, Name, new ParameterExpression[] { (ParameterExpression)Arg1 });
                return this;
            }
        }
        #endregion

        #region Methods
        public Function<TArg1, TReturn> _ (Expression<TArg1> arg)
        {
            return this[arg];
        }

        public Func<Expression<TArg1>, Function<TArg1, TReturn>> Lambda()
        {
            return new Func<Expression<TArg1>, Function<TArg1, TReturn>>((p) => this[p]);
        }
        #endregion
    }

}
