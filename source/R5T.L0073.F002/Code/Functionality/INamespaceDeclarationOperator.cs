using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;

using R5T.L0073.T001;


namespace R5T.L0073.F002
{
    [FunctionalityMarker]
    public partial interface INamespaceDeclarationOperator : IFunctionalityMarker,
        F001.INamespaceDeclarationOperator
    {
        public void Add_Class(
            IWithNamespaceDeclaration withNamespaceDeclaration,
            ClassDeclarationSyntax classDeclaration)
        {
            withNamespaceDeclaration.NamespaceDeclaration = this.Add_Class(
                withNamespaceDeclaration.NamespaceDeclaration,
                classDeclaration);
        }
    }
}
