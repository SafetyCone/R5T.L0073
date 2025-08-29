using System;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

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
            node = this.Indent_DocumentationComments(
                node,
                indentation);

            // Finally, indent just the node itself, unless there is a new line trivia amongst the leading trivia
            // (in which case it was already indented by the new line trivia operation above).
            var anyNewLineLeadingTrivias = Instances.SyntaxNodeOperator.Get_LeadingTrivia(node)
                .Where(Instances.SyntaxTriviaOperator.Is_EndOfLine)
                .Any();

            var indent = !anyNewLineLeadingTrivias;
            if(indent)
            {
                node = this.Indent(
                    node,
                    indentation);
            }

            return node;
        }

        public TNode Indent_DocumentationComments<TNode>(
            TNode node,
            SyntaxTriviaList indentation)
            where TNode : SyntaxNode
        {
            // Find the parent token for each documentation comment exterior trivia,
            // then prepend the indentation to the leading trivia of the token
            // (so the indentation appears before the documentation comment exterior trivia).
            var documentationCommentExteriorTriviaParentTokens = Instances.SyntaxNodeOperator.Get_DescendantTrivias(node)
                .Where(Instances.SyntaxTriviaOperations.Is_Kind(SyntaxKind.DocumentationCommentExteriorTrivia))
                .Select(Instances.SyntaxTriviaOperator.Get_Parent)
                .ToArray();

            var output = Instances.SyntaxNodeOperator.Replace_Tokens_Better(
                    node,
                    documentationCommentExteriorTriviaParentTokens
                        .Select(token =>
                        {
                            var newToken = Instances.SyntaxTokenOperator.Prepend_ToLeadingTrivia(
                                token,
                                indentation);

                            return (token, newToken);
                        })
                    );

            return output;
        }

        public TNode Indent_DocumentationComments<TNode>(
            TNode node)
            where TNode : SyntaxNode
        {
            var output = this.Indent_DocumentationComments(
                node,
                Instances.Indentations.Tab);

            return output;
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
