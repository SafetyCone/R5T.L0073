using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using R5T.T0131;


namespace R5T.L0073.F001
{
    [ValuesMarker]
    public partial interface ISyntaxTokenOperations : IValuesMarker
    {
        public Func<SyntaxToken, bool> Is_Kind(SyntaxKind kind)
        {
            return token => Instances.SyntaxTokenOperator.Is_Kind(
                token,
                kind);
        }
    }
}
