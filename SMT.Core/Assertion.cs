using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SMT
{
    public class Assertion : Formula
    {
        #region Constructor
        internal Assertion(Formula f) : base(f)
        {
            
        }
        #endregion

        #region Overriden methods
        public override string ToString()
        {
            SMTExpressionVisitor visitor = new SMTExpressionVisitor();
            visitor.Visit(LinqExpression);
            return visitor.GeneratedExpression;
        }
        #endregion
        
    }
}
