using System;

using Microsoft.CodeAnalysis;

using R5T.T0142;


namespace R5T.L0073.F001
{
    [DataTypeMarker]
    public class SyntaxTokenSyntaxElement : SyntaxElement
    {
        public override SyntaxElementType ElementType => SyntaxElementType.SyntaxToken;

        public SyntaxToken Token { get; }


        public SyntaxTokenSyntaxElement(SyntaxToken token)
        {
            this.Token = token;
        }
    }
}
