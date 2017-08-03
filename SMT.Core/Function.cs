using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SMT
{
    public class Function<TArg1, TReturn> : Expression<TReturn> where TArg1 : Sort where TReturn : Sort
    {
        #region Constructors
        public Function(Theorem theorem, string name) : base(theorem, name)
        {
            Name = name;
            Const<TArg1> p = new Const<TArg1>(Theorem, Name + "_arg_1");
            Const<TReturn> r = new Const<TReturn>(Theorem, Name + "_return");
            LinqExpression = Expression.Lambda<Func<TArg1, TReturn>>(r, Name, new ParameterExpression[] { (ParameterExpression)p });
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
        #endregion
    }

    


}
