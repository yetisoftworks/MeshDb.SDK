﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MeshyDB.SDK
{
    internal static class PredicateBuilder
    {
        public static Expression Replace(this Expression expression, Expression searchEx, Expression replaceEx)
        {
            return new ReplaceVisitor(searchEx, replaceEx).Visit(expression);
        }

        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var secondBody = expr2.Replace(expr2.Parameters[0], expr1.Parameters[0]);
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, secondBody), expr1.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var secondBody = expr2.Replace(expr2.Parameters[0], expr1.Parameters[0]);
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, secondBody), expr1.Parameters);
        }

        public static Expression<Func<T, bool>> CombineExpressions<T>(IEnumerable<Expression<Func<T, bool>>> expressions)
        {
            if (expressions == null || expressions.Count() == 0)
            {
                return t => true;
            }

            ParameterExpression param = Expression.Parameter(typeof(T));
            var combined = expressions
                            .Select(func => func.Body.Replace(func.Parameters[0], param))
                            .Aggregate((a, b) => Expression.AndAlso(a, b));

            return Expression.Lambda<Func<T, bool>>(combined, param);
        }

        // https://stackoverflow.com/questions/20380078/having-trouble-aggregating-over-a-list-of-expressions-with-expression-andalso
        internal class ReplaceVisitor : ExpressionVisitor
        {
            private readonly Expression from;
            private readonly Expression to;

            public ReplaceVisitor(Expression from, Expression to)
            {
                this.from = from;
                this.to = to;
            }

            public override Expression Visit(Expression node)
            {
                return node == from ? to : base.Visit(node);
            }
        }
    }
}
