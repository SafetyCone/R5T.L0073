using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.L0073.F001.Raw
{
    [ValuesMarker]
    public partial interface IMethodDeclarationOperations : IValuesMarker
    {
        public MethodDeclarationSyntax Add_Body(MethodDeclarationSyntax methodDeclaration)
        {
            return methodDeclaration.WithBody(
                Instances.SyntaxGenerator._Raw.Block());
        }
    }
}
