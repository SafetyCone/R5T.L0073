using System;


namespace R5T.L0073.F001
{
    public class MethodDeclarationOperations : IMethodDeclarationOperations
    {
        #region Infrastructure

        public static IMethodDeclarationOperations Instance { get; } = new MethodDeclarationOperations();


        private MethodDeclarationOperations()
        {
        }

        #endregion
    }
}

namespace R5T.L0073.F001.Raw
{
    public class MethodDeclarationOperations : IMethodDeclarationOperations
    {
        #region Infrastructure

        public static IMethodDeclarationOperations Instance { get; } = new MethodDeclarationOperations();


        private MethodDeclarationOperations()
        {
        }

        #endregion
    }
}
