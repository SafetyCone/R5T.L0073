using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.L0073.F001
{
    [FunctionalityMarker]
    public partial interface ISyntaxParser : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Raw.ISyntaxParser _Raw => Raw.SyntaxParser.Instance;
#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// Moves all descendant token trailing trivia to leading trivia.
        /// </summary>
        public TNode Parse_Node<TNode>(
            string text,
            Func<string, TNode> parser,
            IEnumerable<Func<TNode, TNode>> postParseOperations)
            where TNode : SyntaxNode
        {
            return Instances.SyntaxParser_Internal.Parse(
                text,
                parser,
                postParseOperations
                    .Prepend(
                        Instances.SyntaxNodeOperations.Move_DescendantTrailingTriviaToLeadingTrivia));
        }

        public TNode Parse_Node<TNode>(
            string text,
            Func<string, TNode> parser,
            params Func<TNode, TNode>[] postParseOperations)
            where TNode : SyntaxNode
        {
            return this.Parse_Node(
                text,
                parser,
                postParseOperations.AsEnumerable());
        }

        public CompilationUnitSyntax Parse_CompilationUnit(string text)
        {
            var output = this.Parse_Node(
                text,
                _Raw.Parse_CompilationUnit);

            return output;
        }
    }
}
