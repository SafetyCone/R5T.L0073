using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.L0073.T001;
using R5T.L0073.T003;
using R5T.T0221;
using R5T.T0241;


namespace R5T.L0073.O004
{
    [ContextOperationsMarker]
    public partial interface IDocumentationCommentContextOperations : IContextOperationsMarker
    {
        public Func<TContext, Task> In_DocumentationCommentContext<TContext, TSyntaxNode>(
            out IsSet<IHasSyntaxNode<TSyntaxNode>> syntaxNodeSet,
            IEnumerable<Func<DocumentationCommentContext<TSyntaxNode>, Task>> operations)
            where TContext : IWithSyntaxNode<TSyntaxNode>
            where TSyntaxNode : SyntaxNode
        {
            return async context =>
            {
                var childContext = new DocumentationCommentContext<TSyntaxNode>
                {
                    SyntaxNode = context.SyntaxNode,
                };

                await Instances.ContextOperator.In_Context(
                    childContext,
                    operations);

                context.SyntaxNode = childContext.SyntaxNode;
            };
        }

        public Func<TContext, Task> In_DocumentationCommentContext<TContext, TSyntaxNode>(
            out IsSet<IHasSyntaxNode<TSyntaxNode>> syntaxNodeSet,
            params Func<DocumentationCommentContext<TSyntaxNode>, Task>[] operations)
            where TContext : IWithSyntaxNode<TSyntaxNode>
            where TSyntaxNode : SyntaxNode
        {
            return this.In_DocumentationCommentContext<TContext, TSyntaxNode>(
                out syntaxNodeSet,
                operations.AsEnumerable());
        }
    }
}
