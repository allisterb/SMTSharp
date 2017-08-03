using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SMT
{
    public class Formula : Expression<Bool>
    {
        #region Constructor
        internal Formula(BooleanExpression e) : base(e)
        {
            this.LinqExpression = e.LinqExpression;
        }

        internal Formula(Formula f) : base(f)
        {
            this.LinqExpression = f.LinqExpression;
        }
        #endregion

        #region Overriden methods
        public override bool Equals(object obj)
        {
            if (obj is Formula)
            {
                Formula f = obj as Formula;
                return f.Id == this.Id;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        #endregion
    }
}
