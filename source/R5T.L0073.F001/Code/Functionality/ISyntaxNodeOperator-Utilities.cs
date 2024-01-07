using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.L0073.F001.Utilities
{
    /// <summary>
    /// Utility functions for syntax nodes that you should have to go looking for, rather than just find, on the syntax node operator.
    /// </summary>
    [FunctionalityMarker]
    public partial interface ISyntaxNodeOperator : IFunctionalityMarker
    {
        public TNode AnnotateTokens<TNode>(
            TNode node,
            IEnumerable<SyntaxToken> tokens,
            out Dictionary<SyntaxToken, SyntaxAnnotation> annotationsByInputToken)
            where TNode : SyntaxNode
        {
            return Instances.SyntaxAnnotationOperator.AnnotateTokens(
                node,
                tokens,
                out annotationsByInputToken);
        }

        public TNode AnnotateTrivias<TNode>(
            TNode node,
            IEnumerable<SyntaxTrivia> trivias,
            out Dictionary<SyntaxTrivia, SyntaxAnnotation> annotationsByInputTrivia)
            where TNode : SyntaxNode
        {
            return Instances.SyntaxAnnotationOperator.AnnotateTrivias(
                node,
                trivias,
                out annotationsByInputTrivia);
        }

        public IEnumerable<SyntaxToken> Enumerate_DescendantTokensWithTrailingTrivia(SyntaxNode node)
        {
            var tokens = Instances.SyntaxNodeOperator.Enumerate_DescendantTokens(node);

            var output = tokens
                .Where(Instances.SyntaxTokenOperator.Has_TrailingTrivia)
                ;

            return output;
        }

        public SyntaxToken[] Get_DescendantTokensWithTrailingTrivia(SyntaxNode node)
        {
            var output = this.Enumerate_DescendantTokensWithTrailingTrivia(node)
                .Now();

            return output;
        }

        public SyntaxTrivia[] Get_NewLineTrivias(SyntaxNode node)
        {
            var output = Instances.SyntaxNodeOperator.Get_DescendantTrivias(node)
                .Where(Instances.SyntaxTriviaOperator.Is_EndOfLine)
                .Now();

            return output;
        }

        /// <summary>
        /// Determines if any of the node's tokens contain trailing trivia, returning those that do.
        /// </summary>
        /// <remarks>
        /// This method is useful for checking that the all trailing trivia was moved to be leading trivia on the next token.
        /// </remarks>
        public bool Has_DescendantTokensWithTrailingTrivia(
            SyntaxNode node,
            out IEnumerable<SyntaxToken> tokensWithTrailingTrivia)
        {
            tokensWithTrailingTrivia = this.Enumerate_DescendantTokensWithTrailingTrivia(node);

            var output = tokensWithTrailingTrivia.Any();
            return output;
        }

        /// <summary>
        /// Determines if any of the node's tokens contain trailing trivia, returning those that do,
        /// except if its the last token, which the last token contains trailing trivia, there's nothing that can be done.
        /// </summary>
        /// <inheritdoc cref="Has_DescendantTokensWithTrailingTrivia(SyntaxNode, out IEnumerable{SyntaxToken})" path="/remarks"/>
        public bool Has_DescendantTokensWithTrailingTrivia_ExceptLast(
            SyntaxNode node,
            out IEnumerable<SyntaxToken> tokensWithTrailingTrivia)
        {
            tokensWithTrailingTrivia = this.Enumerate_DescendantTokensWithTrailingTrivia(node)
                // Unless its the last token
                .Where(token =>
                {
                    var isLastToken = Instances.SyntaxTokenOperator.Is_LastToken(token);

                    var output = !isLastToken;
                    return output;
                })
                ;

            var output = tokensWithTrailingTrivia.Any();
            return output;
        }

        public TNode Modify_NewLineContainingTriviaLists<TNode>(
            TNode node,
            Func<SyntaxTriviaList, SyntaxTrivia, SyntaxTriviaList> modifier)
            where TNode : SyntaxNode
        {
            var newLineTrivias = this.Get_NewLineTrivias(node);

            node = this.AnnotateTrivias(
                node,
                newLineTrivias,
                out var annotationsByTrivias);

            foreach (var newLineTriviaAnnotation in annotationsByTrivias.Values)
            {
                var newLineTrivia = Instances.SyntaxNodeOperator.Get_AnnotatedTrivia(
                    node,
                    newLineTriviaAnnotation);

                node = Instances.SyntaxTriviaOperator.Modify_ContainingTriviaList(
                    node,
                    newLineTrivia,
                    trivias => modifier(trivias, newLineTrivia));
            }

            return node;
        }

        /// <summary>
        /// Moves all trailing trivia on tokens within the node to be leading trivia on following tokens within the node.
        /// </summary>
        /// <remarks>
        /// The <see cref="Microsoft.CodeAnalysis.CSharp.SyntaxFactory"/> parse functions output syntax elements with trivia as <em>trailing</em> trivia.
        /// This makes some sense, since it is easier to just add trailing trivia to an existing element instead of accumulating trivia and then adding it to the following element.
        /// (Indeed, ff a following element even follows! What about trivia following the last element?)
        /// However, it is a more useful convention to work with trivia as <em>leading</em> trivia, because that makes it easier to think of trivia as <em>separating</em> trivia.
        /// This utility method is useful 
        /// </remarks>
        public TNode Move_DescendantTrailingTriviaToLeadingTrivia<TNode>(TNode node)
            where TNode : SyntaxNode
        {
            var descendantTokensWithTrailingTrivia = this.Get_DescendantTokensWithTrailingTrivia(node);

            node = Instances.SyntaxAnnotationOperator.AnnotateTokens(
                node,
                descendantTokensWithTrailingTrivia,
                out var annotationsByToken);

            // Iterate over pairs instead of annotations alone to have access to information in the syntax token while debugging.
            foreach (var pair in annotationsByToken)
            {
                var tokenAnnotation = pair.Value;

                // The token as it initiall exists, with trailing trivia.
                var initialTokenWithTrailingTrivia = Instances.SyntaxNodeOperator.Get_AnnotatedToken(
                    node,
                    tokenAnnotation);

                // If the current token is the last in the file, we cannot move trailing trivia to be leading trivia on the next token.
                if(Instances.SyntaxTokenOperator.Is_LastToken(initialTokenWithTrailingTrivia))
                {
                    continue;
                }

                var tokenTrailingTrivia = Instances.SyntaxTokenOperator.Get_TrailingTrivia(initialTokenWithTrailingTrivia);

                var newTokenWithoutTrailingTrivia = Instances.SyntaxTokenOperator.Remove_TrailingTrivia(initialTokenWithTrailingTrivia);

                node = Instances.SyntaxNodeOperator.Replace_Token(
                    node,
                    initialTokenWithTrailingTrivia,
                    newTokenWithoutTrailingTrivia);

                // After the token has been replaced in the node, the node is a new node, and the token's next token will be a new token in the new node.
                // If we do not retrieve this new token, asking for the next token using the old token will give us a token in the old node (which is useless).
                // So we need to ask for the new token.
                var tokenWithoutTrailingTrivia = Instances.SyntaxNodeOperator.Get_AnnotatedToken(
                    node,
                    tokenAnnotation);

                // Get the next token.
                // In getting the next token we do not need to consider directives or documentation comments, i.e. structured trivia.
                // This is because the initial call to get descendant tokens found tokens everywhere (including in any structured trivia),
                // so if our token is inside of a directive or documentation comment, it will be inside of a structured trivia syntax.
                // Assuming that any structured trivia *cannot* itself contain structured trivia (a good assumption),
                // this means we are inside a non-trivia context (which itself might be inside a trivia context, but at the moment we are not)
                // and will not move into a trivia context, so getting the next token without considering structured trivia is safe.
                // We *do* however, want to get zero-width tokens (like end-of-trivia directives) since those can still have leading trivia (the zero-width criterion applies to just the span, not the full-span).
                var initialNextToken = tokenWithoutTrailingTrivia.GetNextToken(
                    includeZeroWidth: true);

                var nextTokenLeadingTrivia = initialNextToken.LeadingTrivia;

                // There is complexity surrounding where to place the prior node's trailing trivia:
                //  * If the token is within a structured trivia:
                //      => Insert token trailing trivia after the trivia containing the token in the leading trivia of the next token.
                //  * Else, prepend prior token trailing trivia to the leading trivia of the next token.
                var tokenIsWithinStructuredTrivia = Instances.SyntaxTokenOperator.Is_InStructuredTrivia(
                    initialNextToken,
                    out var structuredTriviaOrDefault);

                var newNextTokenLeadingTrivia = tokenIsWithinStructuredTrivia
                    ? Instances.SyntaxTriviaListOperator.Insert_After(
                        nextTokenLeadingTrivia,
                        structuredTriviaOrDefault,
                        tokenTrailingTrivia)
                    : Instances.SyntaxTriviaListOperator.Prepend(
                        tokenTrailingTrivia,
                        nextTokenLeadingTrivia)
                    ;

                var newNextToken = initialNextToken.WithLeadingTrivia(newNextTokenLeadingTrivia);

                node = Instances.SyntaxNodeOperator.Replace_Token(
                    node,
                    initialNextToken,
                    newNextToken);
            }

            return node;
        }
    }
}
