using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.L0073.F001
{
    [ValuesMarker]
    public partial interface IClassDeclarationOperations : IValuesMarker
    {
        public Func<ClassDeclarationSyntax, ClassDeclarationSyntax> Add_Method(MethodDeclarationSyntax method)
        {
            return classDeclaration => Instances.ClassDeclarationOperator.Add_Method(
                classDeclaration,
                method);
        }
    }
}
