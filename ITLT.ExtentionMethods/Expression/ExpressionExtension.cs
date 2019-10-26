namespace ITLT.ExtentionMethods
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// Extension Methods of Expression Type
    /// </summary>
    public static class ExpressionExtension
    {
        /// <summary>
        /// Calls the specified expression.
        /// </summary>
        /// <typeparam name="TFunc">The type of the function.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">This method should never be called. It is a marker for constructing filter expressions.</exception>
        public static TFunc Call<TFunc>(this Expression<TFunc> expression)
        {
            throw new InvalidOperationException(
                "This method should never be called. It is a marker for constructing filter expressions.");
        }

        /// <summary>
        /// Substitutes the marker.
        /// </summary>
        /// <typeparam name="TFunc">The type of the function.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static Expression<TFunc> SubstituteMarker<TFunc>(this Expression<TFunc> expression)
        {
            var visitor = new SubstituteExpressionCallVisitor();

            return (Expression<TFunc>)visitor.Visit(expression);
        }
    }

    /// <summary>
    /// Additional Class 
    /// </summary>
    /// <seealso cref="System.Linq.Expressions.ExpressionVisitor" />
    public class SubstituteExpressionCallVisitor : ExpressionVisitor
    {
        /// <summary>
        /// The marker desctiprion
        /// </summary>
        private readonly MethodInfo markerDescription;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubstituteExpressionCallVisitor"/> class.
        /// </summary>
        public SubstituteExpressionCallVisitor()
        {
            this.markerDescription = typeof(ExpressionExtension).GetMethod("Call")
                 .GetGenericMethodDefinition();
            //this.markerDesctiprion = typeof(ExpressionExt).GetMethod(NameOf.nameof(ExpressionExt.Call))
            //     .GetGenericMethodDefinition();
        }

        /// <summary>
        /// Visits the invocation.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        protected override Expression VisitInvocation(InvocationExpression node)
        {
            if (node.Expression.NodeType == ExpressionType.Call && this.IsMarker((MethodCallExpression)node.Expression))
            {
                var parameterReplacer = new SubstituteParameterVisitor(node.Arguments.ToArray(),
                    this.Unwrap((MethodCallExpression)node.Expression));

                var target = parameterReplacer.Replace();

                return Visit(target);
            }

            return base.VisitInvocation(node);
        }

        /// <summary>
        /// Unwraps the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        private LambdaExpression Unwrap(MethodCallExpression node)
        {
            var target = node.Arguments[0];

            return (LambdaExpression)Expression.Lambda(target).Compile().DynamicInvoke();
        }

        /// <summary>
        /// Determines whether the specified node is marker.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>
        ///   <c>true</c> if the specified node is marker; otherwise, <c>false</c>.
        /// </returns>
        private bool IsMarker(MethodCallExpression node)
        {
            return node.Method.IsGenericMethod && node.Method.GetGenericMethodDefinition() == markerDescription;
        }
    }

    /// <summary>
    /// Additional Class 
    /// </summary>
    /// <seealso cref="System.Linq.Expressions.ExpressionVisitor" />
    public class SubstituteParameterVisitor : ExpressionVisitor
    {
        /// <summary>
        /// The expression to visit
        /// </summary>
        private readonly LambdaExpression expressionToVisit;

        /// <summary>
        /// The substitution by parameter
        /// </summary>
        private readonly Dictionary<ParameterExpression, Expression> substitutionByParameter;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubstituteParameterVisitor"/> class.
        /// </summary>
        /// <param name="parameterSubstitutions">The parameter substitutions.</param>
        /// <param name="expressionToVisit">The expression to visit.</param>
        public SubstituteParameterVisitor(Expression[] parameterSubstitutions, LambdaExpression expressionToVisit)
        {
            this.expressionToVisit = expressionToVisit;
            this.substitutionByParameter = expressionToVisit.Parameters
                .Select((parameter, index) => new { Parameter = parameter, Index = index })
                .ToDictionary(pair => pair.Parameter, pair => parameterSubstitutions[pair.Index]);
        }

        /// <summary>
        /// Replaces this instance.
        /// </summary>
        /// <returns></returns>
        public Expression Replace()
        {
            return Visit(expressionToVisit.Body);
        }

        /// <summary>
        /// Visits the parameter.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        protected override Expression VisitParameter(ParameterExpression node)
        {
            Expression substitution;

            if (this.substitutionByParameter.TryGetValue(node, out substitution))
            {
                return Visit(substitution);
            }

            return base.VisitParameter(node);
        }
    }
}