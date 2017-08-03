using System;
using System.Reflection;
using System.Linq.Expressions;

namespace SMT
{
    /// <summary>
    /// Abstracts an SMT formula constant
    /// </summary>
    /// <typeparam name="T">The sort or type of the constant term</typeparam>
    public class Const<T> : Expression<T> where T : Sort
    {
        #region Constructor
        /// <summary>1
        /// Public constructor. Name is required.
        /// </summary>
        /// <param name="name"></param>
        public Const(Theorem theorem, string name) : base(theorem)
        {
            Name = name;
        }
        protected Const(Const<T> t) : base(t) {}
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
            Expression expr = this;
            string[] t = SortType.Name.Split('.');
            return string.Format("(decl-const {0} {1})", this.Name, t[t.Length - 1]);
        }
        #endregion

        #region Properties
        protected static MethodInfo DummyAnd0Method = ClassType.GetRuntimeMethod("DummyAnd0", new[] { typeof(T), typeof(T) });
        protected static MethodInfo DummyAnd1Method = ClassType.GetRuntimeMethod("DummyAnd1", new[] { typeof(Boolean), typeof(T) });
        protected static MethodInfo DummyAnd2Method = ClassType.GetRuntimeMethod("DummyAnd2", new[] { typeof(T), typeof(Boolean) });
        protected static MethodInfo DummyOr0Method = ClassType.GetRuntimeMethod("DummyOr0", new[] { typeof(T), typeof(T) });
        protected static MethodInfo DummyOr1Method = ClassType.GetRuntimeMethod("DummyOr1", new[] { typeof(Boolean), typeof(T) });
        protected static MethodInfo DummyOr2Method = ClassType.GetRuntimeMethod("DummyOr2", new[] { typeof(T), typeof(Boolean) });
        protected static MethodInfo DummyNotMethod = ClassType.GetRuntimeMethod("DummyNot", new[] { typeof(T) });
        #endregion

        #region Methods
        protected Const<T2> Reinterpret<T2>() where T2 : Sort
        {
            return new Const<T2>(this.Theorem, this.Name)
            {
                Id = this.Id,
            };
        }


        public static bool DummyAnd1(Boolean left, Bool right)
        {
            throw new NotImplementedException();
        }

        public static bool DummyAnd2(Bool left, Boolean right)
        {
            throw new NotImplementedException(); ;
        }

        public static bool DummyOr0(T left, T right)
        {
            throw new NotImplementedException();
        }

        public static bool DummyOr1(Boolean left, T right)
        {
            throw new NotImplementedException();
        }

        public static bool DummyOr2(T left, Boolean right)
        {
            throw new NotImplementedException();
        }

        public static bool DummyNot(T b)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Operators
        public static implicit operator ConstantExpression<T>(Const<T> c)
        {
            return new ConstantExpression<T>(c);
        }

       
        #endregion
    }
}
