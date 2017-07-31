using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SMT
{
    /// <summary>
    /// Abstracts an SMT-LIB expression formula
    /// </summary>
    public abstract class Formula
    {
        #region Constructor
        internal Formula(string name, Theorem theorem)
        {
            Id = Guid.NewGuid().ToString("N");
            Type t = this.GetType();
            if (t.GenericTypeArguments.Length > 0)
            {
                this.SortType = t.GenericTypeArguments[t.GenericTypeArguments.Length - 1];
            }
            else SortType = t;
            Name = name;
            Theorem = theorem;
        }
        #endregion

        #region Properties
        public string Name { get; protected set; }
        public string Id { get; protected set; }
        public Type SortType { get; protected set; }
        public Theorem Theorem { get; protected set; }
        #endregion
    }
}
