using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;

using R5T.L0073.T002;


namespace R5T.L0073.O002
{
    [ValuesMarker]
    public partial interface ICompilationUnitOperations : IValuesMarker
    {
        [Obsolete("Bad abstrction. See ICompilationUnitContextOperations.Add_Namespace()")]
        public Func<CompilationUnitSyntax, CompilationUnitSyntax> Add_Namespace_Bad(
            string namespaceName,
            IEnumerable<Func<NamespaceDeclarationSyntax, ICompilationUnitContext, NamespaceDeclarationSyntax>> namespaceModifiers)
        {
            return compilationUnit =>
            {
                var compilationUnitContext = new CompilationUnitContext
                {
                    CompilationUnit = compilationUnit,
                };

                var namespaceDeclaration = Instances.SyntaxGenerator.Namespace(namespaceName);

                foreach (var namespaceModifier in namespaceModifiers)
                {
                    namespaceDeclaration = namespaceModifier(
                        namespaceDeclaration,
                        compilationUnitContext);
                }

                var output = Instances.CompilationUnitOperator.Add_Namespace(
                    // Use the possibly modified compilation unit.
                    compilationUnitContext.CompilationUnit,
                    namespaceDeclaration);

                return output;
            };
        }

        [Obsolete("Bad abstrction. See ICompilationUnitContextOperations.Add_Namespace()")]
        public Func<CompilationUnitSyntax, CompilationUnitSyntax> Add_Namespace_Bad(
            string namespaceName,
            params Func<NamespaceDeclarationSyntax, ICompilationUnitContext, NamespaceDeclarationSyntax>[] namespaceModifiers)
        {
            return this.Add_Namespace_Bad(
                namespaceName,
                namespaceModifiers.AsEnumerable());
        }
    }
}
