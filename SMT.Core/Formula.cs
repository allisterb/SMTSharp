using System;
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
                this.Type = t.GenericTypeArguments[t.GenericTypeArguments.Length - 1];
            }
            else Type = t;
            Name = name;
            Theorem = theorem;
        }
        #endregion

        #region Properties
        public string Name { get; protected set; }
        public string Id { get; protected set; }
        public Type Type { get; protected set; }
        public Theorem Theorem { get; protected set; }
        #endregion
    }
}
