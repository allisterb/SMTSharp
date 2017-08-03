using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SMT
{
    public class Function<TArg1, TArg2, TReturn> : Expression<TReturn> where TArg1 : Sort where TArg2: Sort where TReturn : Sort
    {
        public Function(Theorem theorem, string name) : base(theorem)
        {
            Name = name;
            Const<TArg1> p1 = new Const<TArg1>(Theorem, Name + "_arg_1");
            Const<TArg2> p2 = new Const<TArg2>(Theorem, Name + "_arg_2");
            Const<TReturn> r = new Const<TReturn>(Theorem, Name + "_return");
            LinqExpression = Expression.Lambda<Func<TArg1, TArg2, TReturn>>(r, Name, new ParameterExpression[] { (ParameterExpression) p1, (ParameterExpression) p2 });
        }

        public override string ToString()
        {
            LambdaExpression e = (LambdaExpression)LinqExpression;
            StringBuilder s = new StringBuilder();
            s.AppendFormat("(declare-fun {0} ({1}) {2})", Name, e.Parameters[0].Type.Name, e.Parameters[1].Type.Name, e.ReturnType.Name);
            return s.ToString();
        }
    }
}
