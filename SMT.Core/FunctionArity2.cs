using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SMT
{
    public class Function<TArg1, TArg2, TReturn> : Formula where TArg1 : Sort where TArg2 : Sort where TReturn : Sort
    {
        #region Constructors
        public Function(string name) : base(name) { }
        #endregion

        #region Operators
        public static UnaryExpression operator ~ (Function<TArg1, TArg2, TReturn> f)
        {
            return Expression.Negate(f);
        }

        public static BinaryExpression operator & (Function<TArg1, TArg2, TReturn> left, Function<TArg1, TArg2, TReturn> right)
        {
            return Expression.MakeBinary(ExpressionType.And, left, right);
        }

        public static explicit operator Expression<Func<TArg1, TArg2, TReturn>>(Function<TArg1, TArg2, TReturn> f)
        {
            Const<TArg1> p1 = new Const<TArg1>(f.Name + "_arg_1");
            Const<TArg2> p2 = new Const<TArg2>(f.Name + "_arg_2");
            Const<TReturn> r = new Const<TReturn>(f.Name + "_return");
            return Expression.Lambda<Func<TArg1, TArg2, TReturn>>(r, f.Name, new ParameterExpression[] { (ParameterExpression)p1, (ParameterExpression)p2 });
        }

        public static implicit operator Expression(Function<TArg1, TArg2, TReturn> f)
        {
            return f as Expression<Func<TArg1, TArg2, TReturn>>;
        }

        #endregion

        #region Overriden methods
        public override string ToString()
        {
            Expression<Func<TArg1, TArg2, TReturn>> e = (Expression<Func<TArg1, TArg2, TReturn>>)this;
            StringBuilder s = new StringBuilder();
            s.AppendFormat("declare-fun {0} ({1} {2}) {3}", e.Name, e.Parameters[0].Type.Name, e.Parameters[1].Type.Name, e.ReturnType.Name);
            return s.ToString();
        }
        #endregion

    }
}
