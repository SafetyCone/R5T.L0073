using System;

using Microsoft.CodeAnalysis;

using R5T.T0132;


namespace R5T.L0073.F001
{
    [FunctionalityMarker]
    public partial interface ISyntaxTokenListOperator : IFunctionalityMarker
    {
        public SyntaxToken Get_Last(SyntaxTokenList tokens)
        {
            var output = Instances.ListOperator.Get_Last(tokens);
            return output;
        }
    }
}
