using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SMT
{
    public class Function<TArg1, TArg2, TArg3, TReturn> : Formula where TArg1 : Sort where TArg2 : Sort where TArg3 : Sort where TReturn : Sort
    {
        #region Constructors
        public Function(string name, Theorem theorem) : base(name, theorem) { }
        #endregion

        #region Overriden methods
        public override string ToString()
        {
            Expression<Func<TArg1, TArg2, TArg3, TReturn>> e = (Expression<Func<TArg1, TArg2, TArg3, TReturn>>)this;
            StringBuilder s = new StringBuilder();
            s.AppendFormat("declare-fun {0} ({1}) {2} {3}) {4}", e.Name, e.Parameters[0].Type.Name, e.Parameters[1].Type.Name, e.Parameters[2].Type.Name, e.ReturnType.Name);
            return s.ToString();
        }
        #endregion

        #region Operators
        public static explicit operator Expression<Func<TArg1, TArg2, TArg3, TReturn>>(Function<TArg1, TArg2, TArg3, TReturn> f)
        {
            Const<TArg1> p1 = new Const<TArg1>(f.Name + "_arg_1", f.Theorem);
            Const<TArg2> p2 = new Const<TArg2>(f.Name + "_arg_2", f.Theorem);
            Const<TArg3> p3 = new Const<TArg3>(f.Name + "_arg_3", f.Theorem);
            Const<TReturn> r = new Const<TReturn>(f.Name + "_return", f.Theorem);
            return Expression.Lambda<Func<TArg1, TArg2, TArg3, TReturn>>(r, f.Name, new ParameterExpression[] { (ParameterExpression)p1, (ParameterExpression)p2, (ParameterExpression)p3 });
        }

        public static implicit operator Expression(Function<TArg1, TArg2, TArg3, TReturn> f)
        {
            return f as Expression<Func<TArg1, TArg2, TArg3, TReturn>>;
        }
        #endregion
    }
}
