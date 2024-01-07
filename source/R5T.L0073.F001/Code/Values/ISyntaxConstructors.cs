using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.L0073.F001
{
    [ValuesMarker]
    public partial interface ISyntaxConstructors : IValuesMarker
    {
        public Func<CompilationUnitSyntax> CompilationUnit =>
            () => Instances.SyntaxGenerator.CompilationUnit();

        public Func<MethodDeclarationSyntax> MethodDeclaration(
            TypeSyntax returnType,
            string simpleMethodName)
        {
            return () => Instances.SyntaxGenerator.MethodDeclaration(
                returnType,
                simpleMethodName);
        }

        public Func<MethodDeclarationSyntax> MethodDeclaration_VoidReturn(
            string simpleMethodName)
        {
            return () => Instances.SyntaxGenerator._Raw.MethodDeclaration_VoidReturn(simpleMethodName);
        }
    }
}
