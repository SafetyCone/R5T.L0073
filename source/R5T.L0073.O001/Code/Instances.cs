using System;


namespace R5T.L0073.O001
{
    public static class Instances
    {
        public static F002.IClassDeclarationOperator ClassDeclarationOperator => F002.ClassDeclarationOperator.Instance;
        public static F001.ICompilationUnitOperations CompilationUnitOperations_F001 => F001.CompilationUnitOperations.Instance;
        public static F002.ICompilationUnitOperations CompilationUnitOperations => F002.CompilationUnitOperations.Instance;
        public static F002.ICompilationUnitOperator CompilationUnitOperator => F002.CompilationUnitOperator.Instance;
        public static Z001.IMethodDeclarations MethodDeclarations => Z001.MethodDeclarations.Instance;
        public static F002.ISyntaxGenerator SyntaxGenerator => F002.SyntaxGenerator.Instance;
        public static Z001.IUsingDirectives UsingDirectives => Z001.UsingDirectives.Instance;
    }
}