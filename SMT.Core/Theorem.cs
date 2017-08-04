using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using System.Text;

namespace SMT
{
    public class Theorem
    {
        #region Properties
        Queue<ITerm> Terms = new Queue<ITerm>();
        static char IdentifierNameStart { get; } = 'a';
        #endregion

        #region Overriden methods
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            foreach (ITerm t in Terms)
            {
                s.AppendLine(t.ToString());
            }
            return s.ToString();
        }
        #endregion

        #region Methods
        public Const<T> DeclareConst<T>(string name) where T : Sort
        {
            Const<T> c = new Const<T>(this, name);
            Append(c);
            return c;
        }

        public Const<T>[] DeclareConsts<T>(string baseName, int count) where T : Sort
        {
            int[] names = Enumerable.Range(0, count).ToArray();
            Const<T>[] r = new Const<T>[count];
            for (int n = 0; n < names.Length; n++)
            {
                r[n] = new Const<T>(this, baseName + n.ToString());
                Append(r[n]);
            }
            return r;
        }

        public Function<TArg1, TReturn> DeclareFunc<TArg1, TReturn>(string name) where TArg1 : Sort where TReturn : Sort
        {
            Function<TArg1, TReturn> f = new Function<TArg1, TReturn>(this, name);
            Append(f);
            return f;
        }

        public Function<TArg1, TArg2, TReturn> DeclareFunc<TArg1, TArg2, TReturn>(string name) where TArg1 : Sort where TArg2 : Sort where TReturn : Sort
        {
            Function<TArg1, TArg2, TReturn> f = new Function<TArg1, TArg2, TReturn>(this, name);
            Append(f);
            return f;
        }

        /*
        public Function<TArg1, TArg2, TArg3, TReturn> DeclareFunc<TArg1, TArg2, TArg3, TReturn>(string name) where TArg1 : Sort where TArg2 : Sort where TArg3 : Sort where TReturn : Sort
        {
            Function<TArg1, TArg2, TArg3, TReturn> f = new Function<TArg1, TArg2, TArg3, TReturn>(name, this);
            Append(f);
            return f;
        }
        */

        public Assertion Assert(ConstantExpression<Bool> b)
        {
            Assertion a = new Assertion((BooleanExpression) b);
            Append(a);
            return a;
        }

        public Assertion Assert(UnaryExpression<Bool> b)
        {
            Assertion a = new Assertion((BooleanExpression)b);
            Append(a);
            return a;
        }

        public Assertion Assert(BinaryExpression<Bool> b)
        {
            Assertion a = new Assertion((BooleanExpression)b);
            Append(a);
            return a;
        }


        protected string GetNextAssertionName()
        {
            int i = Terms.Where(fo => fo is Assertion).Count() + 1;
            return string.Format("assert_{0}", i);
        }

        protected void Append<T>(Expression<T> t) where T : Sort
        {
            Terms.Enqueue(t);
        }
        #endregion
    }
}
