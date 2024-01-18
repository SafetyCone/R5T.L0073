using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;

using R5T.L0073.T001;


namespace R5T.L0073.F002
{
    [FunctionalityMarker]
    public partial interface IClassDeclarationOperator : IFunctionalityMarker,
        F001.IClassDeclarationOperator
    {
        public void Add_Method(
            IWithClassDeclaration withClassDeclaration,
            MethodDeclarationSyntax methodDeclaration)
        {
            withClassDeclaration.ClassDeclaration = this.Add_Method(
                withClassDeclaration.ClassDeclaration,
                methodDeclaration);
        }
    }
}
