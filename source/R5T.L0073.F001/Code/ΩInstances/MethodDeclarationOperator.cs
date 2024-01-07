using System;


namespace R5T.L0073.F001
{
    public class MethodDeclarationOperator : IMethodDeclarationOperator
    {
        #region Infrastructure

        public static IMethodDeclarationOperator Instance { get; } = new MethodDeclarationOperator();


        private MethodDeclarationOperator()
        {
        }

        #endregion
    }
}


namespace R5T.L0073.F001.Raw
{
    public class MethodDeclarationOperator : IMethodDeclarationOperator
    {
        #region Infrastructure

        public static IMethodDeclarationOperator Instance { get; } = new MethodDeclarationOperator();


        private MethodDeclarationOperator()
        {
        }

        #endregion
    }
}
