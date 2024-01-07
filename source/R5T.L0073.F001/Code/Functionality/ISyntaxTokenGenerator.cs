using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using R5T.T0132;


namespace R5T.L0073.F001
{
    [FunctionalityMarker]
    public partial interface ISyntaxTokenGenerator : IFunctionalityMarker
    {
        public SyntaxToken From_Kind(SyntaxKind kind)
        {
            var output = SyntaxFactory.Token(kind);
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
    }
}
