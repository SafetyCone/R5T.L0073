using System;


namespace R5T.L0073.O001
{
    public static class Instances
    {
        public static F001.IClassDeclarationOperator ClassDeclarationOperator => F001.ClassDeclarationOperator.Instance;
        public static F001.ICompilationUnitOperations CompilationUnitOperations => F001.CompilationUnitOperations.Instance;
        public static F001.ICompilationUnitOperator CompilationUnitOperator => F001.CompilationUnitOperator.Instance;
        public static Z001.IMethodDeclarations MethodDeclarations => Z001.MethodDeclarations.Instance;
        public static F001.ISyntaxGenerator SyntaxGenerator => F001.SyntaxGenerator.Instance;
        public static Z001.IUsingDirectives UsingDirectives => Z001.UsingDirectives.Instance;
    }
}