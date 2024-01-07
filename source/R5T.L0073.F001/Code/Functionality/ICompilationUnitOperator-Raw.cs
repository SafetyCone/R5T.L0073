using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.L0073.F001.Raw
{
    [FunctionalityMarker]
    public partial interface ICompilationUnitOperator : IFunctionalityMarker
    {
        public CompilationUnitSyntax Add_Namespace(
            CompilationUnitSyntax compilationUnit,
            NamespaceDeclarationSyntax namespaceDeclaration)
        {
            var output = compilationUnit.AddMembers(namespaceDeclaration);
            return output;
        }

        public CompilationUnitSyntax Add_UsingDirective(
            CompilationUnitSyntax compilationUnit,
            UsingDirectiveSyntax usingDirective)
        {
            var output = this.Add_UsingDirectives(
                compilationUnit,
                usingDirective);

            return output;
        }

        public CompilationUnitSyntax Add_UsingDirectives(
            CompilationUnitSyntax compilationUnit,
            params UsingDirectiveSyntax[] usingDirectives)
        {
            var output = compilationUnit.AddUsings(usingDirectives);
            return output;
        }

        public CompilationUnitSyntax Add_UsingDirectives(
            CompilationUnitSyntax compilationUnit,
            IEnumerable<UsingDirectiveSyntax> usingDirectives)
        {
            var output = this.Add_UsingDirectives(
                compilationUnit,
                usingDirectives.ToArray());

            return output;
        }
    }
}
