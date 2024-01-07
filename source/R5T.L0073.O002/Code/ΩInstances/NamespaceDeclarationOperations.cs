using System;


namespace R5T.L0073.O002
{
    public class NamespaceDeclarationOperations : INamespaceDeclarationOperations
    {
        #region Infrastructure

        public static INamespaceDeclarationOperations Instance { get; } = new NamespaceDeclarationOperations();


        private NamespaceDeclarationOperations()
        {
        }

        #endregion
    }
}
