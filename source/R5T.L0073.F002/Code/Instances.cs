using System;


namespace R5T.L0073.F002
{
    public static class Instances
    {
        public static ICompilationUnitOperator CompilationUnitOperator => F002.CompilationUnitOperator.Instance;
        public static L0066.IContextOperator ContextOperator => L0066.ContextOperator.Instance;
        public static INamespaceDeclarationOperator NamespaceDeclarationOperator => F002.NamespaceDeclarationOperator.Instance;
        public static F001.ISyntaxGenerator SyntaxGenerator => F002.SyntaxGenerator.Instance;
    }
}