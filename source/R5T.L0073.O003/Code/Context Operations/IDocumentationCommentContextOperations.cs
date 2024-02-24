using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.L0073.T001;
using R5T.T0221;
using R5T.T0241;


namespace R5T.L0073.O003
{
    /// <summary>
    /// Documentation comment-related context operations that work on <see cref="IHasSyntaxNode{TSyntaxNode}"/>, where TSyntaxNode: <see cref="DocumentationCommentTriviaSyntax"/>.
    /// This allows these operations to be more generally applicable (without requiring implementing a documentation comment-specific context type).
    /// </summary>
    [ContextOperationsMarker]
    public partial interface IDocumentationCommentContextOperations : IContextOperationsMarker
    {
        public Func<TContext, Task> Add_Contents<TContext>(
            IEnumerable<XmlNodeSyntax> contents)
            where TContext : IWithSyntaxNode<DocumentationCommentTriviaSyntax>
        {
            return context =>
            {
                context.SyntaxNode = Instances.DocumentationCommentTriviaOperator.Add_Contents(
                    context.SyntaxNode,
                    contents);

                return Task.CompletedTask;
            };
        }

        public Func<TContext, Task> Add_Contents<TContext>(
            params XmlNodeSyntax[] contents)
            where TContext : IWithSyntaxNode<DocumentationCommentTriviaSyntax>
        {
            return this.Add_Contents<TContext>(
                contents.AsEnumerable());
        }

        public Func<TContext, Task> Add_SummaryElement<TContext>(
            IEnumerable<string> lines)
            where TContext : IWithSyntaxNode<DocumentationCommentTriviaSyntax>
        {
            var content = Instances.SyntaxGenerator.Summary_XmlDocumentationElement(
                    lines);

            var output = this.Add_Contents<TContext>(content);
            return output;
        }

        public Func<TContext, Task> Add_SummaryElement<TContext>(
            params string[] lines)
            where TContext : IWithSyntaxNode<DocumentationCommentTriviaSyntax>
        {
            return this.Add_SummaryElement<TContext>(
                lines.AsEnumerable());
        }

        public Func<TContext, Task> Append_DocumentationComment<TContext, TSyntaxNode>()
            where TContext : IWithSyntaxNode<TSyntaxNode>, IWithSyntaxNode<DocumentationCommentTriviaSyntax>
            where TSyntaxNode : SyntaxNode
        {
            return context =>
            {
                (context as IWithSyntaxNode<TSyntaxNode>).SyntaxNode = Instances.SyntaxNodeOperator.Append_LeadingTrivias(
                    (context as IWithSyntaxNode<TSyntaxNode>).SyntaxNode,
                    (context as IWithSyntaxNode<DocumentationCommentTriviaSyntax>).SyntaxNode.ParentTrivia);

                return Task.CompletedTask;
            };
        }

        /// <summary>
        /// Used when a context cannot implement <see cref="IWithSyntaxNode{TSyntaxNode}"/> for both the primary syntax node type and the documentation comment trivia syntax.
        /// For example, when the context is generic in the syntax node type, or in general when the syntax node type is a base type of documentation comment trivia sytax.
        /// In these cases CS0695 rears its ugly head since the syntax node type parameter might unify with documentation comment trivia syntax.
        /// </summary>
        public Func<TContext, Task> Append_DocumentationComment_ToPrimarySyntaxNode<TContext, TSyntaxNode>()
            where TContext : IWithPrimarySyntaxNode<TSyntaxNode>, IWithSyntaxNode<DocumentationCommentTriviaSyntax>
            where TSyntaxNode : SyntaxNode
        {
            return context =>
            {
                var node = (context as IWithPrimarySyntaxNode<TSyntaxNode>).SyntaxNode;

                var trivia = SyntaxFactory.Trivia((context as IWithSyntaxNode<DocumentationCommentTriviaSyntax>).SyntaxNode);

                (context as IWithPrimarySyntaxNode<TSyntaxNode>).SyntaxNode = Instances.SyntaxNodeOperator.Append_LeadingTrivias(
                    node,
                    trivia,
                    // Add a new line after the documentation comment trivia so the documentation comment is on its own line.
                    Instances.SyntaxTrivias.Whitespace_EndOfLine);

                return Task.CompletedTask;
            };
        }

        public Func<TContext, Task> In_DocumentationCommentContext<TContext, TDocumentationCommentContext, TSyntaxNode>(
            out IsSet<IHasSyntaxNode<TSyntaxNode>> syntaxNodeSet,
            Func<TContext, Task<TDocumentationCommentContext>> documentationCommentContextConstructor,
            IEnumerable<Func<TDocumentationCommentContext, Task>> operations)
            where TContext : IWithSyntaxNode<TSyntaxNode>
            where TDocumentationCommentContext : IWithSyntaxNode<TSyntaxNode>, IWithSyntaxNode<DocumentationCommentTriviaSyntax>
            where TSyntaxNode : SyntaxNode
        {
            return async context =>
            {
                var childContext = await documentationCommentContextConstructor(context);

                await Instances.ContextOperator.In_Context(
                    childContext,
                    operations);
            };
        }

        public Func<TContext, Task> In_DocumentationCommentContext<TContext, TDocumentationCommentContext, TSyntaxNode>(
            out IsSet<IHasSyntaxNode<TSyntaxNode>> syntaxNodeSet,
            Func<TContext, Task<TDocumentationCommentContext>> documentationCommentContextConstructor,
            params Func<TDocumentationCommentContext, Task>[] operations)
            where TContext : IWithSyntaxNode<TSyntaxNode>
            where TDocumentationCommentContext : IWithSyntaxNode<TSyntaxNode>, IWithSyntaxNode<DocumentationCommentTriviaSyntax>
            where TSyntaxNode : SyntaxNode
        {
            return this.In_DocumentationCommentContext(
                out syntaxNodeSet,
                documentationCommentContextConstructor,
                operations.AsEnumerable());
        }

        public Func<TContext, Task> Set_DocumentationComment_New<TContext>(
            out IsSet<IHasDocumentationComment> documentationCommentSet)
            // Use IWithSyntaxNode<> instead of IWithDocumentationComment, since IWithDocumentationComment inherits from IWithSyntaxNode.
            where TContext : IWithSyntaxNode<DocumentationCommentTriviaSyntax>
        {
            return context =>
            {
                context.SyntaxNode = Instances.SyntaxGenerator.DocumentationComment();

                return Task.CompletedTask;
            };
        }
    }
}
