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
            return f as Expression<Func<TArg1, TReturn>>;
        }

        public override string ToString()
        {
            Expression<Func<TArg1, TReturn>> e = (Expression<Func<TArg1, TReturn>>) this;
            StringBuilder s = new StringBuilder();
            s.AppendFormat("declare-fun {0} ({1}) {2}", e.Name, e.Parameters[0].Type.Name, e.ReturnType.Name);
            return s.ToString();
        }
    }

    public class Function<T1, T2, T3> : Formula where T1 : Sort where T2 : Sort where T3 : Sort
    {
        public Function(string name) : base(name) { }

        public static implicit operator Expression(Function<T1, T2, T3> f)
        {
            Const<T1> p1 = new Const<T1>(f.Name + "_arg_1");
            Const<T2> p2 = new Const<T2>(f.Name + "_arg_2");
            Const<T3> r = new Const<T3>(f.Name + "_return");
            return Expression.Lambda<Func<T1, T2, T3>>(r, f.Name, new ParameterExpression[] { (ParameterExpression) p1, (ParameterExpression) p2 });
        }
    }
}
