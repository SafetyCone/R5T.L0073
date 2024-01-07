using System;


namespace R5T.L0073.Z002
{
    public static class Instances
    {
        public static Strings.IIdentifiers Identifiers_Strings => Strings.Identifiers.Instance;
        public static Z001.Strings.IIdentifiers Identifiers_Strings_Net => Z001.Strings.Identifiers.Instance;
        public static IIdentifierNames IdentifierNames => Z002.IdentifierNames.Instance;
        public static F001.ISyntaxGenerator SyntaxGenerator => F001.SyntaxGenerator.Instance;
    }
}