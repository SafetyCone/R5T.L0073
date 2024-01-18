using System;
using System.Collections.Generic;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;

using R5T.L0073.T001;


namespace R5T.L0073.F002
{
    [ValuesMarker]
    public partial interface ICompilationUnitOperations : IValuesMarker
    {
        public Action<TCompilationUnitContext> Add_Namespace<TCompilationUnitContext, TNamespaceDeclarationContext>(
            string namespaceName,
            Func<NamespaceDeclarationSyntax, TCompilationUnitContext, TNamespaceDeclarationContext> namespaceDeclarationContextConstructor,
            IEnumerable<Action<TNamespaceDeclarationContext>> namespaceDeclarationContextActions)
            where TCompilationUnitContext : IWithCompilationUnit
            where TNamespaceDeclarationContext : IHasNamespaceDeclaration
        {
            return compilationUnitContext =>
            {
                var namespaceDeclaration = Instances.SyntaxGenerator.Namespace(namespaceName);

                var namespaceDeclarationContext = namespaceDeclarationContextConstructor(
                    namespaceDeclaration,
                    compilationUnitContext);

                Instances.ContextOperator.In_Context(
                    namespaceDeclarationContext,
                    namespaceDeclarationContextActions);

                Instances.CompilationUnitOperator.Add_Namespace(
                    compilationUnitContext,
                    namespaceDeclarationContext.NamespaceDeclaration);
            };
        }

        public Action<TCompilationUnitContext> Add_UsingDirective<TCompilationUnitContext>(UsingDirectiveSyntax usingDirective)
            // Note: must be generic type to allow inclusion in an enumerable of a generic type.
            where TCompilationUnitContext : IWithCompilationUnit
        {
            return withCompilationUnit =>
            {
                withCompilationUnit.CompilationUnit = Instances.CompilationUnitOperator.Add_UsingDirective(
                    withCompilationUnit.CompilationUnit,
                    usingDirective);
            };
        }
    }
}
