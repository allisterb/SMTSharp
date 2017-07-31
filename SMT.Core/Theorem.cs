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
        Queue<Formula> Formulas = new Queue<Formula>();
        #endregion

        #region Overriden methods
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            foreach (Formula f in Formulas)
            {
                s.AppendLine(f.ToString());
            }
            return s.ToString();
        }
        #endregion

        #region Methods
        public Const<T> DeclareConst<T>(string name) where T : Sort
        {
            Const<T> c = new Const<T>(name, this);
            Append(c);
            return c;
        }
        public Const<T>[] DeclareConsts<T>(string baseName, int count) where T : Sort
        {
            int[] names = Enumerable.Range(0, count).ToArray();
            Const<T>[] r = new Const<T>[count];
            for (int n = 0; n < names.Length; n++)
            {
                r[n] = new Const<T>(baseName + n.ToString(), this);
                Append(r[n]);
            }
            return r;
        }

        public Function<TArg1, TReturn> DeclareFunc<TArg1, TReturn>(string name) where TArg1 : Sort where TReturn : Sort
        {
            Function<TArg1, TReturn> f = new Function<TArg1, TReturn>(name, this);
            Append(f);
            return f;
        }

        public Function<TArg1, TArg2, TReturn> DeclareFunc<TArg1, TArg2, TReturn>(string name) where TArg1 : Sort where TArg2 : Sort where TReturn : Sort
        {
            Function<TArg1, TArg2, TReturn> f = new Function<TArg1, TArg2, TReturn>(name, this);
            Append(f);
            return f;
        }

        public Function<TArg1, TArg2, TArg3, TReturn> DeclareFunc<TArg1, TArg2, TArg3, TReturn>(string name) where TArg1 : Sort where TArg2 : Sort where TArg3 : Sort where TReturn : Sort
        {
            Function<TArg1, TArg2, TArg3, TReturn> f = new Function<TArg1, TArg2, TArg3, TReturn>(name, this);
            Append(f);
            return f;
        }

        public Assertion Assert(Expression e)
        {
            Assertion a = new Assertion(e, GetNextAssertionName(), this);
            Append(a);
            return a;
        }

        protected string GetNextAssertionName()
        {
            int i = Formulas.Where(fo => fo is Assertion).Count() + 1;
            return string.Format("assert{0}", i);
        }

        protected void Append(Formula f)
        {
#if NETSTANDARD1_6
            Formulas.Append(f);
#else
            Formulas.Enqueue(f);
#endif
        }
        #endregion
    }
}
