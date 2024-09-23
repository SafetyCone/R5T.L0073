using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.L0073.Z001
{
    [ValuesMarker]
    public partial interface INamespaceNames : IValuesMarker
    {
        /// <inheritdoc cref="Z0064.Z000.INamespaceNames.System"/>
        public NameSyntax System => Instances.SyntaxGenerator.NamespaceName(
            Instances.NamespaceNames_Strings.System);

        /// <inheritdoc cref="Z0064.Z000.INamespaceNames.System_Collections_Generic"/>
        public NameSyntax System_Collections_Generic => Instances.SyntaxGenerator.NamespaceName(
            Instances.NamespaceNames_Strings.System_Collections_Generic);

        /// <inheritdoc cref="Z0064.Z000.INamespaceNames.System_Threading_Tasks"/>
        public NameSyntax System_Threading_Tasks => Instances.SyntaxGenerator.NamespaceName(
            Instances.NamespaceNames_Strings.System_Threading_Tasks);
    }
}
