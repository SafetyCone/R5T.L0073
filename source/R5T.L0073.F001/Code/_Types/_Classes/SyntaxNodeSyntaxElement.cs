using System;

using Microsoft.CodeAnalysis;

using R5T.T0142;


namespace R5T.L0073.F001
{
    [DataTypeMarker]
    public class SyntaxNodeSyntaxElement : SyntaxElement
    {
        public override SyntaxElementType ElementType => SyntaxElementType.SyntaxNode;

        public SyntaxNode Node { get; }


        public SyntaxNodeSyntaxElement(SyntaxNode node)
        {
            this.Node = node;
        }
    }
}
