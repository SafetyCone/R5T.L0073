using System;


namespace R5T.L0073.O003
{
    public static class Instances
    {
        public static IClassDeclarationContextOperations ClassDeclarationContextOperations => O003.ClassDeclarationContextOperations.Instance;
        public static F001.IClassDeclarationOperator ClassDeclarationOperator => F001.ClassDeclarationOperator.Instance;
        public static ICodeFileContextOperations CodeFileContextOperations => O003.CodeFileContextOperations.Instance;
        public static ICompilationUnitContextOperations CompilationUnitContextOperations => O003.CompilationUnitContextOperations.Instance;
        public static ICompilationUnitOperator CompilationUnitOperator => O003.CompilationUnitOperator.Instance;
        public static L0066.IContextOperator ContextOperator => L0066.ContextOperator.Instance;
        public static IMemberDeclarationContextOperations MemberDeclarationContextOperations => O003.MemberDeclarationContextOperations.Instance;
        public static IMethodDeclarationContextOperations MethodDeclarationContextOperations => O003.MethodDeclarationContextOperations.Instance;
        public static F001.IMethodDeclarationOperator MethodDeclarationOperator => F001.MethodDeclarationOperator.Instance;
        public static INamespaceDeclarationContextOperations NamespaceDeclarationContextOperations => O003.NamespaceDeclarationContextOperations.Instance;
        public static F001.INamespaceDeclarationOperator NamespaceDeclarationOperator => F001.NamespaceDeclarationOperator.Instance;
        public static F001.ISyntaxGenerator SyntaxGenerator => F001.SyntaxGenerator.Instance;
        public static F001.ISyntaxTokenListOperator SyntaxTokenListOperator => F001.SyntaxTokenListOperator.Instance;
        public static F001.ISyntaxTokenOperator SyntaxTokenOperator => F001.SyntaxTokenOperator.Instance;
        public static F001.ISyntaxTriviaLists SyntaxTriviaLists => F001.SyntaxTriviaLists.Instance;
    }
}