using System;

using Microsoft.CodeAnalysis;

using R5T.T0132;


namespace R5T.L0073.F001
{
    public partial interface ISyntaxGenerator : IFunctionalityMarker
    {
        public SyntaxToken Public_Keyword()
        {
            var output = Instances.SyntaxTokenGenerator.Public_Keyword();
            return output;
        }
    }
}
