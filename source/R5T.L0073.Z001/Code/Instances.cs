using System;


namespace R5T.L0073.Z001
{
    public static class Instances
    {
        public static F001.IClassDeclarationOperations ClassDeclarationOperations => F001.ClassDeclarationOperations.Instance;
        public static IClassNames ClassNames => Z001.ClassNames.Instance;
        public static Strings.IClassNames ClassNames_Strings => Strings.ClassNames.Instance;
        public static IExpressionStatements ExpressionStatements => Z001.ExpressionStatements.Instance;
        public static IIdentifierNames IdentifierNames => Z001.IdentifierNames.Instance;
        public static IIdentifiers Identifiers => Z001.Identifiers.Instance;
        public static Strings.IIdentifiers Identifiers_Strings => Strings.Identifiers.Instance;
        public static F001.IMemberDeclarationOperations MemberDeclarationOperations => F001.MemberDeclarationOperations.Instance;
        public static F001.IMethodDeclarationOperations MethodDeclarationOperations => F001.MethodDeclarationOperations.Instance;
        public static IMethodDeclarations MethodDeclarations => Z001.MethodDeclarations.Instance;
        public static F001.IModifiersOperations ModifiersOperations => F001.ModifiersOperations.Instance;
        public static Z0064.Z000.INamespaceNames NamespaceNames_Strings => Z0064.Z000.NamespaceNames.Instance;
        public static INamespaceNames NamespaceNames => Z001.NamespaceNames.Instance;
        public static IParameters Parameters => Z001.Parameters.Instance;
        public static L0066.Content.IStrings Strings_Content => L0066.Content.Strings.Instance;
        public static F001.ISyntaxConstructors SyntaxConstructors => F001.SyntaxConstructors.Instance;
        public static F001.ISyntaxGenerator SyntaxGenerator => F001.SyntaxGenerator.Instance;
        public static F001.ITypes Types => F001.Types.Instance;
    }
}