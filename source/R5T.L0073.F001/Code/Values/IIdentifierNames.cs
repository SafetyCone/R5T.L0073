using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.L0073.F001
{
    [ValuesMarker]
    public partial interface IIdentifierNames : IValuesMarker
    {
#pragma warning disable IDE1006 // Naming Styles

        public IdentifierNameSyntax var => Instances.SyntaxGenerator.IdentifierName(
            Instances.Identifiers.var);

#pragma warning restore IDE1006 // Naming Styles


        /// <inheritdoc cref="Strings.IIdentifiers.Task"/>
        public IdentifierNameSyntax Task => Instances.SyntaxGenerator.IdentifierName(
            Instances.Identifiers_Strings.Task);
    }
}
