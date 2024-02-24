using System;
using System.Linq;
using System.Threading.Tasks.Sources;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.L0073.F001
{
    [FunctionalityMarker]
    public partial interface ISyntaxTokenOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Raw.ISyntaxTokenOperator _Raw => Raw.SyntaxTokenOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public SyntaxKind Get_Kind(SyntaxToken token)
        {
            var output = token.Kind();
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Get_NextToken_Absolute(SyntaxToken)"/> as the default.
        /// </summary>
        public SyntaxToken Get_NextToken(SyntaxToken token)
        {
            var output = this.Get_NextToken_Absolute(token);
            return output;
        }

        /// <summary>
        /// Gets the absolute next token, which includes tokens of all special cases (zero-width, skipped, include directives, or documentation comments).
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Y000.Documentation.ForSyntaxToken.AbsoluteNextOrPreviousToken" path="/summary"/>
        /// </remarks>
        public SyntaxToken Get_NextToken_Absolute(SyntaxToken token)
        {
            var hasNextToken = this.Has_NextToken_Absolute(
                token,
                out var nextToken);

            if (!hasNextToken)
            {
                throw Instances.Exceptions.TokenHadNoNextTokenException;
            }

            return nextToken;
        }

        /// <summary>
        /// Get the next token without considering any of the possible special cases (zero-width, skipped, include directives, or documentation comments).
        /// Note: because none of the special cases will be considered to be the next token (zero-width, skipped, include directives, or documentation comments).
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Y000.Documentation.ForSyntaxToken.SimpleNextOrPreviousToken" path="/summary"/>
        /// </remarks>
        public SyntaxToken Get_NextToken_Simple(SyntaxToken token)
        {
            var hasNextToken = this.Has_NextToken_Simple(
                token,
                out var nextToken);

            if (!hasNextToken)
            {
                throw Instances.Exceptions.TokenHadNoNextTokenException;
            }

            return nextToken;
        }

        /// <summary>
        /// <inheritdoc cref="Y000.Documentation.ForSyntaxToken.AbsoluteNextOrPreviousToken" path="/summary"/>
        /// </summary>
        public SyntaxToken Get_NextTokenOrNone_Absolute(SyntaxToken token)
        {
            var output = token.GetNextToken(
                includeZeroWidth: true,
                includeSkipped: true,
                includeDirectives: true,
                includeDocumentationComments: true);

            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Y000.Documentation.ForSyntaxToken.SimpleNextOrPreviousToken" path="/summary"/>
        /// </summary>
        public SyntaxToken Get_NextTokenOrNone_Simple(SyntaxToken token)
        {
            var output = token.GetNextToken();
            return output;
        }

        public SyntaxNode Get_ParentOrDefault(SyntaxToken token)
        {
            var output = token.Parent;
            return output;
        }

        public SyntaxNode Get_Parent(SyntaxToken token)
        {
            var output = token.Parent;
            return output;
        }

        public SyntaxToken Get_PreviousToken_Absolute(SyntaxToken token)
        {
            var hasPreviousToken = this.Has_PreviousToken_Absolute(
                token,
                out var previousToken);

            if(!hasPreviousToken)
            {
                throw Instances.Exceptions.TokenHadNoPreviousTokenException;
            }

            return previousToken;
        }

        public SyntaxToken Get_PreviousToken_Simple(SyntaxToken token)
        {
            var hasPreviousToken = this.Has_PreviousToken_Simple(
                token,
                out var previousToken);

            if (!hasPreviousToken)
            {
                throw Instances.Exceptions.TokenHadNoPreviousTokenException;
            }

            return previousToken;
        }

        /// <summary>
        /// <inheritdoc cref="Y000.Documentation.ForSyntaxToken.AbsoluteNextOrPreviousToken" path="/summary"/>
        /// </summary>
        public SyntaxToken Get_PreviousTokenOrNone_Absolute(SyntaxToken token)
        {
            var output = token.GetPreviousToken(
                includeZeroWidth: true,
                includeSkipped: true,
                includeDirectives: true,
                includeDocumentationComments: true);

            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Y000.Documentation.ForSyntaxToken.SimpleNextOrPreviousToken" path="/summary"/>
        /// </summary>
        public SyntaxToken Get_PreviousTokenOrNone_Simple(SyntaxToken token)
        {
            var output = token.GetPreviousToken();
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Get_PreviousToken_Absolute(SyntaxToken)"/> as the default.
        /// </summary>
        public SyntaxToken Get_PreviousToken(SyntaxToken token)
        {
            var output = this.Get_PreviousToken_Absolute(token);
            return output;
        }

        public SyntaxTriviaList Get_TrailingTrivia(SyntaxToken token)
        {
            var output = token.TrailingTrivia;
            return output;
        }

        public bool Has_LeadingTrivia(SyntaxToken token)
        {
            var output = token.HasLeadingTrivia;
            return output;
        }

        public bool Has_NextToken_Absolute(
            SyntaxToken token,
            out SyntaxToken nextTokenOrNone)
        {
            nextTokenOrNone = this.Get_NextTokenOrNone_Absolute(token);

            var output = this.Is_Not_None(nextTokenOrNone);
            return output;
        }

        public bool Has_NextToken_Simple(
            SyntaxToken token,
            out SyntaxToken previousTokenOrNone)
        {
            previousTokenOrNone = this.Get_NextTokenOrNone_Simple(token);

            var output = this.Is_Not_None(previousTokenOrNone);
            return output;
        }

        public bool Has_PreviousToken_Absolute(
            SyntaxToken token,
            out SyntaxToken previousTokenOrNone)
        {
            previousTokenOrNone = this.Get_PreviousTokenOrNone_Absolute(token);

            var output = this.Is_Not_None(previousTokenOrNone);
            return output;
        }

        public bool Has_PreviousToken_Simple(
            SyntaxToken token,
            out SyntaxToken previousTokenOrNone)
        {
            previousTokenOrNone = this.Get_PreviousTokenOrNone_Simple(token);

            var output = this.Is_Not_None(previousTokenOrNone);
            return output;
        }

        public bool Has_TrailingTrivia(SyntaxToken token)
        {
            var output = token.HasTrailingTrivia;
            return output;
        }

        public bool Has_TrailingTrivia(
            SyntaxToken token,
            out SyntaxTriviaList trailingTriviaOrEmpty)
        {
            var output = this.Has_TrailingTrivia(token);

            trailingTriviaOrEmpty = this.Get_TrailingTrivia(token);

            return output;
        }

        public bool Is_NotDefault(SyntaxToken token)
        {
            var output = Instances.DefaultOperator.Is_NotDefault(token);
            return output;
        }

        /// <summary>
        /// Is the token a descendant of the given node?
        /// </summary>
        public bool Is_Descendant(
            SyntaxToken token,
            SyntaxNode possibleAncestorNode)
        {
            var output = Instances.SyntaxNodeOperator.Contains(
                possibleAncestorNode,
                token);

            return output;
        }

        public bool Is_InStructuredTrivia(
            SyntaxToken token,
            out SyntaxTrivia structuredTriviaOrDefault)
        {
            var isPartOfStructuredTrivia = token.IsPartOfStructuredTrivia();
            if (!isPartOfStructuredTrivia)
            {
                structuredTriviaOrDefault = Instances.SyntaxTriviaOperator.New();

                return false;
            }

            // Now we know the toke is in structured trivia, so it is guaranteed to have a structured trivia syntax parent.
            var structuredTriviaSyntaxParent = token.Parent;
            while (true)
            {
                if(structuredTriviaSyntaxParent is StructuredTriviaSyntax)
                {
                    break;
                }
                else
                {
                    structuredTriviaSyntaxParent = structuredTriviaSyntaxParent.Parent;
                }
            }

            structuredTriviaOrDefault = (structuredTriviaSyntaxParent as StructuredTriviaSyntax).ParentTrivia;
            return true;
        }

        public bool Is_Kind(
            SyntaxToken token,
            SyntaxKind kind)
        {
            var output = token.IsKind(kind);
            return output;
        }

        public bool Is_LastToken(SyntaxToken token)
        {
            // Determine if the token is the last token by determining if the next token (considering all special cases, because files can end with special cases).
            var nextToken = this.Get_NextToken_Absolute(token);

            var output = this.Is_None(nextToken);
            return output;
        }

        /// <summary>
        /// Is this token the none token?
        /// (For example, at the end of a file.)
        /// </summary>
        public bool Is_None(SyntaxToken token)
        {
            var output = this.Is_Kind(
                token,
                SyntaxKind.None);

            return output;
        }

        public bool Is_Not_None(SyntaxToken token)
        {
            var isNone = this.Is_None(token);

            var output = !isNone;
            return output;
        }

        /// <summary>
        /// Constructs a new syntax token.
        /// </summary>
        public SyntaxToken New()
        {
            var output = new SyntaxToken();
            return output;
        }

        public SyntaxToken Prepend_ToLeadingTrivia(
            SyntaxToken token,
            SyntaxTrivia trivia)
        {
            var output = token.WithLeadingTrivia(
                token.LeadingTrivia
                    .Prepend(trivia));

            return output;
        }

        public SyntaxToken Prepend_ToLeadingTrivia(
            SyntaxToken token,
            SyntaxTriviaList trivias)
        {
            var output = token.WithLeadingTrivia(
                token.LeadingTrivia
                    .Prepend(trivias));

            return output;
        }

        public SyntaxToken Prepend_NewLine(SyntaxToken token)
        {
            var output = this.Prepend_ToLeadingTrivia(
                token,
                Instances.SyntaxTrivias.Whitespace_EndOfLine);

            return output;
        }

        public SyntaxToken Prepend_Space(SyntaxToken token)
        {
            var output = token.WithLeadingTrivia(
                token.LeadingTrivia
                    .Prepend(Instances.SyntaxTrivias.Whitespace_Space));

            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Without_TrailingTrivia(SyntaxToken)"/>.
        /// </summary>
        public SyntaxToken Remove_TrailingTrivia(SyntaxToken token)
        {
            var output = this.Without_TrailingTrivia(token);
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Without_LeadingTrivia(SyntaxToken)"/>.
        /// </summary>
        public SyntaxToken Remove_LeadingTrivia(SyntaxToken token)
        {
            var output = this.Without_LeadingTrivia(token);
            return output;
        }

        public void Verify_IsDescendantToken(
            SyntaxToken token,
            SyntaxNode possibleAncestorNode)
        {
            var isDescendant = this.Is_Descendant(
                token,
                possibleAncestorNode);

            if(!isDescendant)
            {
                throw new Exception("Token was not a descendant of the node.");
            }
        }

        public void Verify_IsKind(
            SyntaxToken token,
            SyntaxKind kind)
        {
            var isKind = this.Is_Kind(
                token,
                kind);

            if(!isKind)
            {
                throw new Exception($"Syntax token was of wrong kind. Expected {kind}, found {token.Kind()}");
            }
        }

        public SyntaxToken Without_LeadingTrivia(SyntaxToken token)
        {
            // Providing no trivia to WithLeadingTrivia() creates a new token without any leading trivia.
            var output = token.WithLeadingTrivia();
            return output;
        }

        public SyntaxToken Without_TrailingTrivia(SyntaxToken token)
        {
            // Providing no trivia to WithTrailingTrivia() creates a new token without any trailing trivia.
            var output = token.WithTrailingTrivia();
            return output;
        }
    }
}
