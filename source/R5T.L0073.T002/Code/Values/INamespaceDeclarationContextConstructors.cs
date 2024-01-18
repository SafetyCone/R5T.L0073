using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;

using R5T.L0073.T001;


namespace R5T.L0073.T002
{
    [ValuesMarker]
    public partial interface INamespaceDeclarationContextConstructors : IValuesMarker
    {
        public INamespaceDeclarationContext New_NamespaceDeclarationContext<TCompilationUnitContext>(
            NamespaceDeclarationSyntax namespaceDeclaration,
            TCompilationUnitContext compilationUnitContext)
            // Must be generic to match constructor delegate.
            where TCompilationUnitContext : IHasCompilationUnit
        {
            var namespaceDeclarationContext = new NamespaceDeclarationContext
            {
                NamespaceDeclaration = namespaceDeclaration,
                CompilationUnit = compilationUnitContext.CompilationUnit,
            };

            return namespaceDeclarationContext;
        }
    }
}
