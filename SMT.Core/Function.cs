using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SMT
{
    public class Function<TArg1, TReturn> : Formula where TArg1 : Sort where TReturn : Sort
    {
        public Function(string name) : base(name) {}

        public static explicit operator Expression<Func<TArg1, TReturn>>(Function<TArg1, TReturn> f)
        {
            Const<TArg1> p = new Const<TArg1>(f.Name + "_arg_1");
            Const<TReturn> r = new Const<TReturn>(f.Name + "_return");
            return Expression.Lambda<Func<TArg1, TReturn>>(r, f.Name, new ParameterExpression[] { (ParameterExpression) p });

        }

        public static implicit operator Expression(Function<TArg1, TReturn> f)
        {
            return (Expression<Func<TArg1, TReturn>>) f;
        }

        public override string ToString()
        {
            Expression<Func<TArg1, TReturn>> e = (Expression<Func<TArg1, TReturn>>) this;
            StringBuilder s = new StringBuilder();
            s.AppendFormat("declare-fun {0} ({1}) {2}", e.Name, e.Parameters[0].Type.Name, e.ReturnType.Name);
            return s.ToString();
        }
    }

    


}
