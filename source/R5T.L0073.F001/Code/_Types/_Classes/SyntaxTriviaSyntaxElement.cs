using System;

using Microsoft.CodeAnalysis;

using R5T.T0142;


namespace R5T.L0073.F001
{
    [DataTypeMarker]
    public class SyntaxTriviaSyntaxElement : SyntaxElement
    {
        public override SyntaxElementType ElementType => SyntaxElementType.SyntaxTrivia;

        public SyntaxTrivia Trivia { get; }


        public SyntaxTriviaSyntaxElement(SyntaxTrivia trivia)
        {
            this.Trivia = trivia;
        }
    }
}
