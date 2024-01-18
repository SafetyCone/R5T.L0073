using System;


namespace R5T.L0073.O002
{
    public static class Instances
    {
        public static F001.IClassDeclarationOperator ClassDeclarationOperator => F001.ClassDeclarationOperator.Instance;
        public static F001.ICompilationUnitOperator CompilationUnitOperator => F001.CompilationUnitOperator.Instance;
        public static T002.INamespaceDeclarationContextConstructors NamespaceDeclarationContextConstructors => T002.NamespaceDeclarationContextConstructors.Instance;
        public static F001.INamespaceDeclarationOperator NamespaceDeclarationOperator => F001.NamespaceDeclarationOperator.Instance;
        public static F001.ISyntaxGenerator SyntaxGenerator => F001.SyntaxGenerator.Instance;
    }
}