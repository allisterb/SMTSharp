﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SMT
{
    internal class AssertionExpressionVisitor : ExpressionVisitor
    {
        #region Constructors
        internal AssertionExpressionVisitor() : base()
        {

        }
        #endregion

        protected override Expression VisitConstant(ConstantExpression node)
        {
            Context.AppendFormat("{0}", node.Value);
            return node;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            Context.AppendFormat("{0}", node.Name);
            return node;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            Visit(node.Left);
            Context.AppendFormat(" {0} ", GetExpressionTypeSymbol(node.NodeType));
            Visit(node.Right);
            return node;
        }


        protected override Expression VisitUnary(UnaryExpression node)
        {
            Context.AppendFormat("{0}", GetExpressionTypeSymbol(node.NodeType));
            Visit(node.Operand);
            return node;
        }

        #region Methods
        protected string GetExpressionTypeSymbol(ExpressionType type)
        {
            switch(type)
            {
                case ExpressionType.And:
                    return "and";
                case ExpressionType.Or:
                    return "or";
                case ExpressionType.Not:
                    return "!";
                default:
                    return type.ToString();
            }
        }
        #endregion


        #region Properties
        public string GeneratedExpression
        {
            get
            {
                return Context.ToString();
            }
        }
        protected StringBuilder Context { get; set; } = new StringBuilder();
        #endregion
    }
}