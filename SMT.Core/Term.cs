using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SMT
{
    /// <summary>
    /// Abstracts an SMT-LIB formula term
    /// </summary>
    public abstract class Term<T> : ITerm where T : Sort
    {
        #region Constructor
        internal Term(Theory theory, string name) : this(theory)
        {
            Name = name;
        }

        internal Term(Theory theory)
        {
            Id = Guid.NewGuid().ToString("N");
            Theory = Theory;
        }

        internal Term(Term<T> t)
        {
            this.Id = t.Id;
            this.Name = t.Name;
            this.Theory = t.Theory;
        }
        #endregion

        #region Properties
        public static Type SortType { get; } = typeof(T);
        public static string SortTypeName { get; } = SortType.Name;
        public string Name { get; protected set; }
        public string Id { get; protected set; }
        public Theory Theory { get; protected set; }
        #endregion
     }
}
