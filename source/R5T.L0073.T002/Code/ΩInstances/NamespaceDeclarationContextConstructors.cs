using System;


namespace R5T.L0073.T002
{
    public class NamespaceDeclarationContextConstructors : INamespaceDeclarationContextConstructors
    {
        #region Infrastructure

        public static INamespaceDeclarationContextConstructors Instance { get; } = new NamespaceDeclarationContextConstructors();


        private NamespaceDeclarationContextConstructors()
        {
        }

        #endregion
    }
}
