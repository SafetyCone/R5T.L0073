using System;
using System.Collections.Generic;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.L0073.F001
{
    [ValuesMarker]
    public partial interface ICompilationUnitOperations : IValuesMarker
    {
        public Func<CompilationUnitSyntax, CompilationUnitSyntax> Add_Namespace(
            NamespaceDeclarationSyntax namespaceDeclaration)
        {
            return compilationUnit => Instances.CompilationUnitOperator.Add_Namespace(
                compilationUnit,
                namespaceDeclaration);
        }

        public Func<CompilationUnitSyntax, CompilationUnitSyntax> Add_Namespace(
            string namespaceName,
            IEnumerable<Func<NamespaceDeclarationSyntax, NamespaceDeclarationSyntax>> namespaceModifiers)
        {
            return compilationUnit =>
            {
                var namespaceDeclaration = Instances.SyntaxGenerator.Namespace(namespaceName);

                foreach (var namespaceModifier in namespaceModifiers)
                {
                    namespaceDeclaration = namespaceModifier(namespaceDeclaration);
                }

                var output = Instances.CompilationUnitOperator.Add_Namespace(
                    compilationUnit,
                    namespaceDeclaration);

                return output;
            };
        }

        public Func<CompilationUnitSyntax, CompilationUnitSyntax> Add_UsingDirective(
            UsingDirectiveSyntax usingDirective)
        {
            return compilationUnit => Instances.CompilationUnitOperator.Add_UsingDirective(
                compilationUnit,
                usingDirective);
        }

        public Func<CompilationUnitSyntax, CompilationUnitSyntax> Add_UsingDirectives(
            params UsingDirectiveSyntax[] usingDirectives)
        {
            return compilationUnit => Instances.CompilationUnitOperator.Add_UsingDirectives(
                compilationUnit,
                usingDirectives);
        }

        public Func<CompilationUnitSyntax, CompilationUnitSyntax> Add_UsingDirectives(
            IEnumerable<UsingDirectiveSyntax> usingDirectives)
        {
            return compilationUnit => Instances.CompilationUnitOperator.Add_UsingDirectives(
                compilationUnit,
                usingDirectives);
        }
    }
}
