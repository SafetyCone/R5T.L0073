using System;
using System.Collections.Generic;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;

using R5T.L0073.T001;


namespace R5T.L0073.O002
{
    [ValuesMarker]
    public partial interface ICompilationUnitContextOperations : IValuesMarker
    {
        public Action<TCompilationUnitContext> Add_Namespace<TCompilationUnitContext, TNamespaceDeclarationContext>(
            string namespaceName,
            Func<NamespaceDeclarationSyntax, TCompilationUnitContext, TNamespaceDeclarationContext> namespaceDeclarationContextConstructor,
            IEnumerable<Action<TNamespaceDeclarationContext>> namespaceModifiers)
            where TCompilationUnitContext : IWithCompilationUnit
        {
            return compilationUnitContext =>
            {
                var namespaceDeclaration = Instances.SyntaxGenerator.Namespace(namespaceName);

                var namespaceDeclarationContext = namespaceDeclarationContextConstructor(
                    namespaceDeclaration,
                    compilationUnitContext);

                foreach (var namespaceModifier in namespaceModifiers)
                {
                    namespaceModifier(namespaceDeclarationContext);
                }

                compilationUnitContext.CompilationUnit = Instances.CompilationUnitOperator.Add_Namespace(
                    // Use the possibly modified namespace declaration.
                    compilationUnitContext.CompilationUnit,
                    namespaceDeclaration);
            };
        }
    }
}
