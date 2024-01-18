using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.L0073.Z001
{
    /// <summary>
    /// See also: <see cref="IIdentifiers"/>, which are the <see cref="SyntaxToken"/> values corresponding to these <see cref="IdentifierNameSyntax"/> values.
    /// </summary>
    [ValuesMarker]
    public partial interface IIdentifierNames : IValuesMarker
    {
#pragma warning disable IDE1006 // Naming Styles

        /// <inheritdoc cref="Strings.IVariableNames.app"/>
        public IdentifierNameSyntax app => Instances.SyntaxGenerator.IdentifierName(
            Instances.Identifiers_Strings.app);

        /// <inheritdoc cref="Strings.IVariableNames.builder"/>
        public IdentifierNameSyntax builder => Instances.SyntaxGenerator.IdentifierName(
            Instances.Identifiers_Strings.builder);

#pragma warning restore IDE1006 // Naming Styles


        /// <inheritdoc cref="Strings.IMethodNames.Build"/>
        public IdentifierNameSyntax Build => Instances.SyntaxGenerator.IdentifierName(
            Instances.Identifiers_Strings.Build);

        /// <inheritdoc cref="Strings.ITypeNames.Console"/>
        public IdentifierNameSyntax Console => Instances.SyntaxGenerator.IdentifierName(
            Instances.Identifiers_Strings.Console);

        /// <inheritdoc cref="Strings.IMethodNames.Run"/>
        public IdentifierNameSyntax Run => Instances.SyntaxGenerator.IdentifierName(
            Instances.Identifiers_Strings.Run);

        /// <inheritdoc cref="Strings.IMethodNames.WriteLine"/>
        public IdentifierNameSyntax WriteLine => Instances.SyntaxGenerator.IdentifierName(
            Instances.Identifiers_Strings.WriteLine);
    }
}
