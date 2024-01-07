using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.L0073.F001.Raw
{
    [FunctionalityMarker]
    public partial interface IClassDeclarationOperator : IFunctionalityMarker
    {
        public ClassDeclarationSyntax Add_Method(
            ClassDeclarationSyntax classDeclaration,
            MethodDeclarationSyntax method)
        {
            var output = classDeclaration.AddMembers(method);
            return output;
        }
    }
}
