using System;

using Microsoft.CodeAnalysis;

using R5T.T0131;


namespace R5T.L0073.F001
{
    [ValuesMarker]
    public partial interface ISpacings : IValuesMarker
    {
        public SyntaxTriviaList Space => Instances.SyntaxTriviaLists.Space;
    }
}
