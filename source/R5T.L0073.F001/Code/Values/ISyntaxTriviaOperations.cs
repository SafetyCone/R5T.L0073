using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using R5T.T0131;


namespace R5T.L0073.F001
{
    [ValuesMarker]
    public partial interface ISyntaxTriviaOperations : IValuesMarker
    {
        public Func<SyntaxTrivia, bool> Is_Kind(SyntaxKind kind)
        {
            return trivia => Instances.SyntaxTriviaOperator.Is_Kind(
                trivia,
                kind);
        }
    }
}
