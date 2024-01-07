using System;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using R5T.T0132;


namespace R5T.L0073.F001
{
    [FunctionalityMarker]
    public partial interface ISyntaxTriviaOperator : IFunctionalityMarker
    {
        public SyntaxKind Get_Kind(SyntaxTrivia trivia)
        {
            var output = trivia.Kind();
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Get_ParentToken(SyntaxTrivia)"/> as the default.
        /// </summary>
        public SyntaxToken Get_Parent(SyntaxTrivia trivia)
        {
            var output = this.Get_ParentToken(trivia);
            return output;
        }

        public SyntaxToken Get_ParentToken(SyntaxTrivia trivia)
        {
            var output = trivia.Token;
            return output;
        }

        public bool Is_Kind(
            SyntaxTrivia trivia,
            SyntaxKind kind)
        {
            var output = trivia.IsKind(kind);
            return output;
        }

        public bool Is_NotDefault(SyntaxTrivia trivia)
        {
            var output = Instances.DefaultOperator.Is_NotDefault(trivia);
            return output;
        }

        public bool Is_EndOfLine(SyntaxTrivia trivia)
        {
            var output = this.Is_Kind(
                trivia,
                SyntaxKind.EndOfLineTrivia);

            return output;
        }

        public TNode Modify_ContainingTriviaList<TNode>(
            TNode node,
            SyntaxTrivia trivia,
            Func<SyntaxTriviaList, SyntaxTriviaList> modifier)
            where TNode : SyntaxNode
        {
            var token = this.Get_ParentToken(trivia);

            var newToken = token;

            var triviaIsInLeadingTrivia = Instances.SyntaxTriviaListOperator.Contains(
                token.LeadingTrivia,
                trivia);

            if (triviaIsInLeadingTrivia)
            {
                var newLeadingTrivia = modifier(token.LeadingTrivia);

                newToken = newToken.WithLeadingTrivia(newLeadingTrivia);
            }

            var triviaIsInTrailingTrivia = Instances.SyntaxTriviaListOperator.Contains(
                token.TrailingTrivia,
                trivia);

            if (triviaIsInTrailingTrivia)
            {
                var newTrailingTrivia = modifier(token.LeadingTrivia);

                newToken = newToken.WithTrailingTrivia(newTrailingTrivia);
            }

            node = Instances.SyntaxNodeOperator.Replace_Token(
                node,
                token,
                newToken);

            return node;
        }

        public SyntaxTrivia New()
        {
            var output = new SyntaxTrivia();
            return output;
        }

        public SyntaxTrivia New(
            SyntaxKind kind,
            string text)
        {
            var output = SyntaxFactory.SyntaxTrivia(
                kind,
                text);

            return output;
        }

        public SyntaxTrivia New_EndOfLine(string text)
        {
            var output = this.New(
                SyntaxKind.EndOfLineTrivia,
                text);

            return output;
        }

        public SyntaxTrivia New_Whitespace(string text)
        {
            var output = this.New(
                SyntaxKind.WhitespaceTrivia,
                text);

            return output;
        }

        public void Verify_IsKind(
            SyntaxTrivia trivia,
            SyntaxKind kind)
        {
            var isKind = this.Is_Kind(
                trivia,
                kind);

            if(!isKind)
            {
                var triviaKind = this.Get_Kind(trivia);

                throw new Exception($"Syntax trivia was of wrong type. Expected {kind}, found {triviaKind}.");
            }
        }
    }
}
