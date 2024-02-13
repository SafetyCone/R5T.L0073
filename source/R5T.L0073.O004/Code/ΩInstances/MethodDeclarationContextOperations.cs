using System;


namespace R5T.L0073.O004
{
    public class MethodDeclarationContextOperations : IMethodDeclarationContextOperations
    {
        #region Infrastructure

        public static IMethodDeclarationContextOperations Instance { get; } = new MethodDeclarationContextOperations();


        private MethodDeclarationContextOperations()
        {
        }

        #endregion
    }
}
