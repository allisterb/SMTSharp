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
        internal Term(Theorem theorem, string name) : this(theorem)
        {
            Name = name;
        }

        internal Term(Theorem theorem)
        {
            Id = Guid.NewGuid().ToString("N");
            Theorem = theorem;
        }

        internal Term(Term<T> t)
        {
            this.Id = t.Id;
            this.Name = t.Name;
            this.Theorem = t.Theorem;
        }
        #endregion

        #region Properties
        public static Type ClassType { get; } = typeof(Term<T>);
        public static Type SortType { get; } = typeof(T);
        public static string SortTypeName { get; } = SortType.Name;
        public string Name { get; protected set; }
        public string Id { get; protected set; }
        public Theorem Theorem { get; protected set; }
        #endregion
     }
}
