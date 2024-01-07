using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.L0073.F001.Raw
{
    [FunctionalityMarker]
    public partial interface INamespaceDeclarationOperator : IFunctionalityMarker
    {
        public NamespaceDeclarationSyntax Add_Class(
            NamespaceDeclarationSyntax namespaceDeclaration,
            ClassDeclarationSyntax classDeclaration)
        {
            var output = namespaceDeclaration.AddMembers(classDeclaration);
            return output;
        }
    }
}
