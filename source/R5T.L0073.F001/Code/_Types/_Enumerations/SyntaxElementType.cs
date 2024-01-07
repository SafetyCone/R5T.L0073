using System;

using R5T.T0142;


namespace R5T.L0073.F001
{
    /// <summary>
    /// Allows specifying what syntax type a syntax element is. 
    /// </summary>
    [DataTypeMarker]
    public enum SyntaxElementType
    {
        SyntaxNode,
        SyntaxToken,
        SyntaxTrivia
    }
}
