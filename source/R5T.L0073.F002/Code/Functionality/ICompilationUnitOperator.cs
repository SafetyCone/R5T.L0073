using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;

using R5T.L0073.T001;


namespace R5T.L0073.F002
{
    [FunctionalityMarker]
    public partial interface ICompilationUnitOperator : IFunctionalityMarker,
        F001.ICompilationUnitOperator
    {
        public void Add_Namespace(
            IWithCompilationUnit withCompilationUnit,
            NamespaceDeclarationSyntax namespaceDeclaration)
        {
            withCompilationUnit.CompilationUnit = this.Add_Namespace(
                withCompilationUnit.CompilationUnit,
                namespaceDeclaration);
        }

        public void Add_UsingDirective(
            IWithCompilationUnit withCompilationUnit,
            UsingDirectiveSyntax usingDirective)
        {
            withCompilationUnit.CompilationUnit = this.Add_UsingDirective(
                withCompilationUnit.CompilationUnit,
                usingDirective);
        }
    }
}
