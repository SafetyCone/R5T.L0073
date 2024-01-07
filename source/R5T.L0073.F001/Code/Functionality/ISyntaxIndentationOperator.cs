using System;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using R5T.Extensions;
using R5T.T0132;


namespace R5T.L0073.F001
{
    /// <summary>
    /// Functionality for indenting syntax elements.
    /// </summary>
    [FunctionalityMarker]
    public partial interface ISyntaxIndentationOperator : IFunctionalityMarker
    {
        public TNode Indent_Block<TNode>(TNode node)
            where TNode : SyntaxNode
        {
            return this.Indent_Block(
                node,
                Instances.Indentations.Tab);
        }

        /// <summary>
        /// Indents the code of a node as a block.
        /// </summary>
        /// <param name="indentation">Indentation does not include a leading new line, which would be line leading.</param>
        public TNode Indent_Block<TNode>(
            TNode node,
            // Indentation does not include new line (which would be line leading).
            SyntaxTriviaList indentation)
            where TNode : SyntaxNode
        {
            // Modify the elements within the node.
            node = Instances.SyntaxNodeOperator_Utilities.Modify_NewLineContainingTriviaLists(
                node,
                (trivias, newLineTrivia) =>
                {
                    var newTrivias = Instances.SyntaxTriviaListOperator.Insert_After(
                        trivias,
                        newLineTrivia,
                        indentation);

                    return newTrivias;
                });

            // Modify any XML documentation (which uses it's own indentation elements).
            var documentationCommentExteriorTrivias = Instances.SyntaxNodeOperator.Get_DescendantTrivias(
                node,
                SyntaxKind.DocumentationCommentExteriorTrivia);

            var triviaReplacementPairs = documentationCommentExteriorTrivias
                .Select(trivia =>
                {
                    var newTrivia = Instances.SyntaxTriviaOperator.New(
                        SyntaxKind.DocumentationCommentExteriorTrivia,
                        indentation.ToFullString() + trivia.ToString());

                    return (trivia, newTrivia);
                });

            node = Instances.SyntaxNodeOperator.Replace_Trivias_Better(
                node,
                triviaReplacementPairs);

            // Finally, indent just the node itself.
            node = this.Indent(
                node,
                indentation);

            return node;
        }

        /// <summary>
        /// Indents the node by the given indentation.
        /// </summary>
        /// <remarks>
        /// Note: "indent" only applies the indentation to the start of the given node, not all descendants of the node.
        /// To indent the node and all descendants, see <see cref="Indent_Block{TNode}(TNode, SyntaxTriviaList)"/>
        /// </remarks>
        public TNode Indent<TNode>(
            TNode node,
            SyntaxTriviaList indentation)
            where TNode : SyntaxNode
        {
            // Append a new-line trivia to the leading trivia of the node.
            node = node.WithLeadingTrivia(
                node.GetLeadingTrivia()
                    .Append(
                        indentation
                    )
                );

            return node;
        }

        public TNode Indent<TNode>(TNode node)
            where TNode : SyntaxNode
        {
            return this.Indent(
                node,
                Instances.Indentations.Tab);
        }
    }
}
