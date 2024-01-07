using System;


namespace R5T.L0073.Z001
{
    public class MethodDeclarations : IMethodDeclarations
    {
        #region Infrastructure

        public static IMethodDeclarations Instance { get; } = new MethodDeclarations();


        private MethodDeclarations()
        {
        }

        #endregion
    }
}


namespace R5T.L0073.Z001.Signatures
{
    public class MethodDeclarations : IMethodDeclarations
    {
        #region Infrastructure

        public static IMethodDeclarations Instance { get; } = new MethodDeclarations();


        private MethodDeclarations()
        {
        }

        #endregion
    }
}
