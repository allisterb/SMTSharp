using System;
using System.Reflection;
using System.Linq.Expressions;

namespace SMT
{
    /// <summary>
    /// Abstracts an SMT formula constant
    /// </summary>
    /// <typeparam name="T">The sort or type of the constant term</typeparam>
    public class Const<T> : ConstantExpression<T> where T : Sort
    {
        #region Constructor
        /// <summary>1
        /// Public constructor. Name is required.
        /// </summary>
        /// <param name="name"></param>
        public Const(Theory theory, string name) : base(theory, name) {}
        #endregion

        #region Overriden methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Const<T>)
            {
                Const<T> o = obj as Const<T>;
                return this.Id == o.Id;
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override string ToString()
        {
            string[] t = SortType.Name.Split('.');
            return string.Format("(decl-const {0} {1})", this.Name, t[t.Length - 1]);
        }
        #endregion

        #region Methods
        protected Const<T2> Reinterpret<T2>() where T2 : Sort
        {
            return new Const<T2>(this.Theory, this.Name)
            {
                Id = this.Id,
            };
        }
        #endregion
    }
}
