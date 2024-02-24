using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.L0073.T001;
using R5T.T0137;


namespace R5T.L0073.T003
{
    [ContextImplementationMarker]
    public class DocumentationCommentContext<TSyntaxNode> : IContextImplementationMarker,
        IWithPrimarySyntaxNode<TSyntaxNode>,
        IWithSyntaxNode<DocumentationCommentTriviaSyntax>,
        IWithDocumentationComment
        where TSyntaxNode : SyntaxNode
    {
        public TSyntaxNode SyntaxNode { get; set; }
        public DocumentationCommentTriviaSyntax DocumentationComment { get; set; }

        DocumentationCommentTriviaSyntax IWithSyntaxNode<DocumentationCommentTriviaSyntax>.SyntaxNode
        {
            get => this.DocumentationComment;
            set => this.DocumentationComment = value;
        }

        DocumentationCommentTriviaSyntax IHasSyntaxNode<DocumentationCommentTriviaSyntax>.SyntaxNode => this.DocumentationComment;
    }
}
