using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.L0073.F001
{
    public partial interface ISyntaxTokenOperator : IFunctionalityMarker
    {
        public TNode Ensure_HasNoTrailingTrivia<TNode>(
            SyntaxToken token,
            TNode ancestorNode)
            where TNode : SyntaxNode
        {
            var hasTrailingTrivia = this.Has_TrailingTrivia(token);
            if(hasTrailingTrivia)
            {
                var newAncestorNode = this.Remove_TrailingTrivia(
                    token,
                    ancestorNode);

                return newAncestorNode;
            }
            else
            {
                // Nothing to do.
                return ancestorNode;
            }
        }

        public SyntaxToken Ensure_HasNoLeadingTrivia(SyntaxToken token)
        {
            var hasLeadingTrivia = this.Has_LeadingTrivia(token);

            var output = hasLeadingTrivia
                ? this.Without_LeadingTrivia(token)
                : token
                ;

            return output;
        }

        public SyntaxToken Ensure_HasNoTrailingTrivia(SyntaxToken token)
        {
            var hasTrailingTrivia = this.Has_TrailingTrivia(token);

            var output = hasTrailingTrivia
                ? this.Without_TrailingTrivia(token)
                : token
                ;

            return output;
        }

        public TNode Remove_TrailingTrivia<TNode>(
            SyntaxToken token,
            TNode ancestorNode)
            where TNode : SyntaxNode
        {
            var tokenWithoutTrailingTrivia = this.Without_TrailingTrivia(token);

            var newAncestorNode = Instances.SyntaxNodeOperator.Replace_Token_Better(
                ancestorNode,
                token,
                tokenWithoutTrailingTrivia);

            return newAncestorNode;
        }

        public SyntaxToken Set_LeadingTrivia(
            SyntaxToken token,
            SyntaxTriviaList leadingTrivia)
        {
            var output = token.WithLeadingTrivia(leadingTrivia);
            return output;
        }

        public TNode Set_LeadingTrivia<TNode>(
            SyntaxToken token,
            SyntaxTriviaList leadingTrivia,
            TNode ancestorNode)
            where TNode : SyntaxNode
        {
            var tokenWithNewLeadingTrivia = this.Set_LeadingTrivia(
                token,
                leadingTrivia);

            var newAncestorNode = Instances.SyntaxNodeOperator.Replace_Token_Better(
                ancestorNode,
                token,
                tokenWithNewLeadingTrivia);

            return newAncestorNode;
        }

        public SyntaxToken Set_TrailingTrivia(
            SyntaxToken token,
            SyntaxTriviaList trailingTrivia)
        {
            var output = token.WithLeadingTrivia(trailingTrivia);
            return output;
        }

        public TNode Set_TrailingTrivia<TNode>(
            SyntaxToken token,
            SyntaxTriviaList trailingTrivia,
            TNode ancestorNode)
            where TNode : SyntaxNode
        {
            var tokenWithNewTrailingTrivia = this.Set_TrailingTrivia(
                token,
                trailingTrivia);

            var newAncestorNode = Instances.SyntaxNodeOperator.Replace_Token_Better(
                ancestorNode,
                token,
                tokenWithNewTrailingTrivia);

            return newAncestorNode;
        }

        /// <summary>
        /// Unchecked in the sense that no check is performed to ensure the previous token is actually the token's previous token.
        /// </summary>
        public TNode Set_TrailingSeparatingSpacing_NextTokenUnchecked<TNode>(
            SyntaxToken token,
            SyntaxToken nextToken,
            SyntaxTriviaList separatingSpacing,
            TNode ancestorNode)
            where TNode : SyntaxNode
        {
            // Verify the token is actually a descendant of the given ancestor node. 
            this.Verify_IsDescendantToken(
                token,
                ancestorNode);

            try
            {
                // Verify that the token's next token is also a descendant of the given ancestor node. 
                this.Verify_IsDescendantToken(
                    nextToken,
                    ancestorNode);
            }
            catch (Exception isNotDescendantException)
            {
                throw new Exception(
                    "Token's next token was not a descendant of the same ancestor node.",
                    isNotDescendantException);
            }

            // Ensure the current token has no trailing trivia.
            var newTokenWithoutTrailingTrivia = this.Ensure_HasNoTrailingTrivia(token);

            // Set the leading trivia of the next token.
            var newNextTokenWithLeadingTrivia = this.Set_LeadingTrivia(
                nextToken,
                separatingSpacing);

            // Now replace tokens.
            var newAncestorNode = Instances.SyntaxNodeOperator.Replace_Tokens_Better(
                ancestorNode,
                Instances.EnumerableOperator.From(
                    (token, newTokenWithoutTrailingTrivia),
                    (nextToken, newNextTokenWithLeadingTrivia)
                )
            );

            return newAncestorNode;
        }

        /// <summary>
        /// For a token descendant of a node, set the (leading) separating spacing for the token.
        /// </summary>
        public TNode Set_TrailingSeparatingSpacing<TNode>(
            SyntaxToken token,
            SyntaxTriviaList separatingSpacing,
            TNode ancestorNode)
            where TNode : SyntaxNode
        {
            // Get the next token.
            var nextToken = this.Get_NextTokenOrNone_Absolute(token);

            // If the previous token is none, just modify the token.
            // Use trailing trivia, even though that's not canonical.
            var nextTokenIsNone = this.Is_None(nextToken);
            if (nextTokenIsNone)
            {
                return this.Set_TrailingTrivia(
                    token,
                    separatingSpacing,
                    ancestorNode);
            }

            // Else, handle both tokens.
            return this.Set_TrailingSeparatingSpacing_NextTokenUnchecked(
                token,
                nextToken,
                separatingSpacing,
                ancestorNode);
        }

        /// <summary>
        /// Unchecked in the sense that no check is performed to ensure the previous token is actually the token's previous token.
        /// </summary>
        public TNode Set_SeparatingSpacing_PreviousTokenUnchecked<TNode>(
            SyntaxToken token,
            SyntaxToken previousToken,
            SyntaxTriviaList separatingSpacing,
            TNode ancestorNode)
            where TNode : SyntaxNode
        {
            // Verify the token is actually a descendant of the given ancestor node. 
            this.Verify_IsDescendantToken(
                token,
                ancestorNode);

            try
            {
                // Verify that the token's previous token is also a descendant of the given ancestor node. 
                this.Verify_IsDescendantToken(
                    previousToken,
                    ancestorNode);
            }
            catch (Exception isNotDescendantException)
            {
                throw new Exception(
                    "Token's previous token was not a descendant of the same ancestor node.",
                    isNotDescendantException);
            }

            // Ensure the previous token has no trailing trivia.
            var newPreviousTokenWithoutTrailingTrivia = this.Ensure_HasNoTrailingTrivia(previousToken);

            // Set the leading trivia of the token.
            var newTokenWithLeadingTrivia = this.Set_LeadingTrivia(
                token,
                separatingSpacing);

            // Now replace tokens.
            var newAncestorNode = Instances.SyntaxNodeOperator.Replace_Tokens_Better(
                ancestorNode,
                Instances.EnumerableOperator.From(
                    (token, newTokenWithLeadingTrivia),
                    (previousToken, newPreviousTokenWithoutTrailingTrivia)
                )
            );

            return newAncestorNode;
        }

        /// <summary>
        /// For a token descendant of a node, set the (leading) separating spacing for the token.
        /// </summary>
        public TNode Set_SeparatingSpacing<TNode>(
            SyntaxToken token,
            SyntaxTriviaList separatingSpacing,
            TNode ancestorNode)
            where TNode : SyntaxNode
        {
            // Get the previous token.
            var previousToken = this.Get_PreviousTokenOrNone_Absolute(token);

            // If the previous token is none, just modify the token.
            var previousTokenIsNone = this.Is_None(previousToken);
            if(previousTokenIsNone)
            {
                return this.Set_LeadingTrivia(
                    token,
                    separatingSpacing,
                    ancestorNode);
            }

            // Else, handle both tokens.
            return this.Set_SeparatingSpacing_PreviousTokenUnchecked(
                token,
                previousToken,
                separatingSpacing,
                ancestorNode);
        }
    }
}
