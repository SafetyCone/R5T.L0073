using System;


namespace R5T.L0073.F001
{
    public class NamespaceDeclarationOperator : INamespaceDeclarationOperator
    {
        #region Infrastructure

        public static INamespaceDeclarationOperator Instance { get; } = new NamespaceDeclarationOperator();


        private NamespaceDeclarationOperator()
        {
        }

        #endregion
    }
}


namespace R5T.L0073.F001.Raw
{
    public class NamespaceDeclarationOperator : INamespaceDeclarationOperator
    {
        #region Infrastructure

        public static INamespaceDeclarationOperator Instance { get; } = new NamespaceDeclarationOperator();


        private NamespaceDeclarationOperator()
        {
        }

        #endregion
    }
}
