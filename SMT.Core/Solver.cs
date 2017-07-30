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

        #region Methods
        public Const<T> DeclareConst<T>(string name) where T : Sort
        {
            Const<T> c = new Const<T>(name);
            Formulas.Append(c);
            return c;
        }
        public Const<T>[] DeclareConsts<T>(string baseName, int count) where T : Sort
        {
            int[] names = Enumerable.Range(0, count).ToArray();
            Const<T>[] r = new Const<T>[count];
            for (int n = 0; n < names.Length; n++)
            {
                r[n] = new Const<T>(baseName + n.ToString());
                Formulas.Append(r[n]);
            }
            return r;
        }

        public Function<TArg1, TReturn> DeclareFunc<TArg1, TReturn>(string name) where TArg1 : Sort where TReturn : Sort
        {
            Function<TArg1, TReturn> f = new Function<TArg1, TReturn>(name);
            Formulas.Append(f);
            return f;
        }
        #endregion



    }
}
