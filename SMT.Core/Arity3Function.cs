using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SMT
{
    public class Function<TArg1, TArg2, TArg3, TReturn> : Expression<TReturn> where TArg1 : Sort where TArg2 : Sort where TArg3 : Sort where TReturn : Sort
    {
        #region Constructors
        public Function(Theory theory, string name) : base(theory, name) { }
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
        #endregion
    }
}
