using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;

using R5T.L0073.T001;


namespace R5T.L0073.T002
{
    [ValuesMarker]
    public partial interface IClassDeclarationContextConstructors : IValuesMarker
    {
        public IClassDeclarationContext New_ClassDeclarationContext<TNamespaceDeclarationContext>(
            ClassDeclarationSyntax classDeclaration,
            TNamespaceDeclarationContext namespaceDeclarationContext)
            // Must be generic to match constructor delegate.
            where TNamespaceDeclarationContext :
                IHasCompilationUnit,
                IHasNamespaceDeclaration
        {
            var classDeclarationContext = new ClassDeclarationContext
            {
                CompilationUnit = namespaceDeclarationContext.CompilationUnit,
                NamespaceDeclaration = namespaceDeclarationContext.NamespaceDeclaration,
                ClassDeclaration = classDeclaration,
            };

            return classDeclarationContext;
        }
    }
}
