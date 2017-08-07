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
        internal Term(Problem solution, string name) : this(solution)
        {
            Name = name;
        }

        internal Term(Problem solution)
        {
            Id = Guid.NewGuid().ToString("N");
            Solution = solution;
        }

        internal Term(Term<T> t)
        {
            this.Id = t.Id;
            this.Name = t.Name;
            this.Solution = t.Solution;
        }
        #endregion

        #region Properties
        public static Type SortType { get; } = typeof(T);
        public static string SortTypeName { get; } = SortType.Name;
        public string Name { get; protected set; }
        public string Id { get; protected set; }
        public Problem Solution { get; protected set; }
        #endregion
     }
}
