using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.L0073.F001
{
    [ValuesMarker]
    public partial interface IPredefinedTypes : IValuesMarker
    {
        public PredefinedTypeSyntax String => Instances.SyntaxGenerator.PredefinedType(
            Instances.SyntaxTokens.String);

        public PredefinedTypeSyntax Void => Instances.SyntaxGenerator.PredefinedType(
            Instances.SyntaxTokens.Void);
    }
}
