using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.L0073.Z001
{
    [ValuesMarker]
    public partial interface IUsingDirectives : IValuesMarker
    {
        /// <inheritdoc cref="INamespaceNames.System"/>
        public UsingDirectiveSyntax System => Instances.SyntaxGenerator.UsingDirective(
            Instances.NamespaceNames.System);

        /// <inheritdoc cref="INamespaceNames.System_Collections_Generic"/>
        public UsingDirectiveSyntax System_Collections_Generic => Instances.SyntaxGenerator.UsingDirective(
            Instances.NamespaceNames.System_Collections_Generic);

        /// <inheritdoc cref="INamespaceNames.System_Threading_Tasks"/>
        public UsingDirectiveSyntax System_Threading_Tasks => Instances.SyntaxGenerator.UsingDirective(
            Instances.NamespaceNames.System_Threading_Tasks);
    }
}
