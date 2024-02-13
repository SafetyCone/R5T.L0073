using System;


namespace R5T.L0073.O004
{
    public class NamespaceDeclarationContextOperations : INamespaceDeclarationContextOperations
    {
        #region Infrastructure

        public static INamespaceDeclarationContextOperations Instance { get; } = new NamespaceDeclarationContextOperations();


        private NamespaceDeclarationContextOperations()
        {
        }

        #endregion
    }
}
