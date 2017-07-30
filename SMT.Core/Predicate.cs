using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SMT
{
    public class Predicate
    {
        public Predicate(Expression e)
        {
            Expr = e;
        }

        #region Properties
        public Expression Expr { get; protected set; }
        #endregion

    }
}
