using System;

using R5T.T0142;


namespace R5T.L0073.F001
{
    [DataTypeMarker]
    public abstract class SyntaxElement
    {
        public abstract SyntaxElementType ElementType { get; }
    }
}
