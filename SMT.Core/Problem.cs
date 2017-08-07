using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMT
{
    public abstract class Theory<TSort> : Theory where TSort : Sort
    {
        public Theory() : base() { }

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

        public Const<TSort> DeclareConst(string name)
        {
            Const<TSort> c = new Const<TSort>(this, name);
            Append(c);
            return c;
        }

        public Const<TSort>[] DeclareConsts(string baseName, int count)
        {
            int[] names = Enumerable.Range(0, count).ToArray();
            Const<TSort>[] r = new Const<TSort>[count];
            for (int n = 0; n < names.Length; n++)
            {
                r[n] = new Const<TSort>(this, baseName + n.ToString());
                Append(r[n]);
            }
            return r;
        }

        public Function<TSort> DeclareFunc(string name)
        {
            Function<TSort> f = new Function<TSort>(this, name);
            Append(f);
            return f;
        }

        public Function<TArg1, TArg2> DeclareFunc<TArg1, TArg2>(string name) where TArg1 : TSort where TArg2 : TSort
        {
            Function<TArg1, TArg2> f = new Function<TArg1, TArg2>(this, name);
            Append(f);
            return f;
        }

    }
}