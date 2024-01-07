using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using R5T.T0131;


namespace R5T.L0073.F001
{
    [ValuesMarker]
    public partial interface IIdentifiers : IValuesMarker
    {
#pragma warning disable IDE1006 // Naming Styles

        public SyntaxToken var => Instances.SyntaxGenerator.Identifier(
            Instances.Identifiers_Strings.var);

#pragma warning restore IDE1006 // Naming Styles
    }
}
