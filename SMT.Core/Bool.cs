using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SMT
{
    public class Bool : Sort
    {
        public bool Val { get; set; } = false;

        #region Operators
        public static bool operator ! (Bool b)
        {
            return !b.Val;
        }
        #endregion
    }
}
