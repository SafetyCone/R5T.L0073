using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.L0073.F001.Raw
{
    [FunctionalityMarker]
    public partial interface IMethodDeclarationOperator : IFunctionalityMarker
    {
        public MethodDeclarationSyntax Add_Statement(
            MethodDeclarationSyntax methodDeclaration,
            StatementSyntax statement)
        {
            return methodDeclaration.AddBodyStatements(statement);
        }
    }
}
