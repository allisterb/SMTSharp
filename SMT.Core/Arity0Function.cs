﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SMT
{
    public class Function<TReturn> : Expression<TReturn> where TReturn : Sort
    {
        #region Constructors
        public Function(Theory theory, string name) : base(theory, name)
        {
            Return = new ConstantExpression<TReturn>(Theory, Name);
            LinqExpression = Expression.Lambda(Return, Name, new ParameterExpression[0]);
        }
        #endregion

        #region Overriden methods
        public override string ToString()
        {
            LambdaExpression e = (LambdaExpression)LinqExpression;
            StringBuilder s = new StringBuilder();
            s.AppendFormat("(declare-fun {0} () {1})", Name, e.ReturnType.Name);
            return s.ToString();
        }
        #endregion

        #region Properties
        public static Type ClassType { get; } = typeof(Function<TReturn>);
        public static Type ReturnType { get; } = typeof(TReturn);
        public ConstantExpression<TReturn> Return { get; }
        #endregion

        #region Methods
        public Func<Function<TReturn>> Lambda()
        {
            return new Func<Function<TReturn>>(() => this);
        }
        #endregion
    }
}
