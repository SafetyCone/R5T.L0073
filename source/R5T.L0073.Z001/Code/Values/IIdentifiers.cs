using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.L0073.Z001
{
    /// <summary>
    /// See also: <see cref="IIdentifierNames"/>, which are the <see cref="IdentifierNameSyntax"/> values corresponding to these <see cref="SyntaxToken"/> identifiers.
    /// </summary>
    [ValuesMarker]
    public partial interface IIdentifiers : IValuesMarker,
        IClassNames
    {
        /// <inheritdoc cref="Strings.IVariableNames.args"/>
#pragma warning disable IDE1006 // Naming Styles
        public SyntaxToken args => Instances.SyntaxGenerator.Identifier(
            Instances.Identifiers_Strings.args);
#pragma warning restore IDE1006 // Naming Styles

        /// <inheritdoc cref="Strings.IMethodNames.Main"/>
        public SyntaxToken Main => Instances.SyntaxGenerator.Identifier(
            Instances.Identifiers_Strings.Main);
    }
}
