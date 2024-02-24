using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using R5T.T0132;


namespace R5T.L0073.F001
{
    [FunctionalityMarker]
    public partial interface ISyntaxTokenGenerator : IFunctionalityMarker
    {
        public SyntaxToken From(SyntaxKind kind)
        {
            var output = SyntaxFactory.Token(kind);
            return output;
        }

        public SyntaxToken From(
            SyntaxKind kind,
            string text)
        {
            var output = SyntaxFactory.Token(
                Instances.SyntaxTriviaLists.Empty,
                kind,
                text,
                text,
                Instances.SyntaxTriviaLists.Empty);

            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="From(SyntaxKind)"/>.
        /// </summary>
        public SyntaxToken From_Kind(SyntaxKind kind)
        {
            var output = this.From(kind);
            return output;
        }

        public SyntaxToken Identifier(string value)
        {
            var output = SyntaxFactory.Identifier(value);
            return output;
        }

        public SyntaxToken Keyword(SyntaxKind keyword)
        {
            var output = SyntaxFactory.Token(keyword);
            return output;
        }

        /// <summary>
        /// A single space with the XML documentation comment exterior trivia (<inheritdoc cref="ISyntaxTrivias.DocumentationCommentExteriorTrivia" path="/summary"/>) as its leading trivia.
        /// </summary>
        public SyntaxToken XmlDocumentationCommentLeadingSpace()
        {
            var output = Instances.SyntaxGenerator.XmlTextLiteral(
                Instances.Strings.Space)
                .WithLeadingTrivia(
                    Instances.SyntaxTrivias.DocumentationCommentExteriorTrivia);

            return output;
        }
    }
}
