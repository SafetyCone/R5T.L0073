using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.L0073.F001
{
    public partial interface ISyntaxGenerator : IFunctionalityMarker
    {
        public CompilationUnitSyntax Create_CompilationUnit(
            IEnumerable<Func<CompilationUnitSyntax, CompilationUnitSyntax>> modifiers)
        {
            var compilationUnit = this.CompilationUnit();

            var output = this.Build(
                compilationUnit,
                modifiers
            );

            return output;
        }

        public CompilationUnitSyntax Create_CompilationUnit(
            params Func<CompilationUnitSyntax, CompilationUnitSyntax>[] modifiers)
        {
            return this.Create_CompilationUnit(modifiers.AsEnumerable());
        }

        public NamespaceDeclarationSyntax Create_Namespace(
            string namespaceName,
            IEnumerable<Func<NamespaceDeclarationSyntax, NamespaceDeclarationSyntax>> modifiers)
        {
            var namespaceDeclaration = this.Namespace(namespaceName);

            var output = this.Build(
                namespaceDeclaration,
                modifiers);

            return output;
        }

        public NamespaceDeclarationSyntax Create_Namespace(
            string namespaceName,
            params Func<NamespaceDeclarationSyntax, NamespaceDeclarationSyntax>[] modifiers)
        {
            return this.Create_Namespace(
                namespaceName,
                modifiers.AsEnumerable());
        }
    }
}
