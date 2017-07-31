using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SMT
{
    public class Assertion : Formula
    {
        #region Constructor
        public Assertion(Expression expr, string name, Theorem theorem) : base(name, theorem)
        {
            Expr = expr;
        }
        #endregion

        #region Overriden methods
        public override string ToString()
        {
            AssertionExpressionVisitor visitor = new AssertionExpressionVisitor();
            visitor.Visit(Expr);
            return visitor.GeneratedExpression;
        }
        #endregion
        
        #region Properties
        public Expression Expr { get; protected set; }
        #endregion
    }
}
