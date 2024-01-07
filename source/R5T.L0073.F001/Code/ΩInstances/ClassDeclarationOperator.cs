using System;


namespace R5T.L0073.F001
{
    public class ClassDeclarationOperator : IClassDeclarationOperator
    {
        #region Infrastructure

        public static IClassDeclarationOperator Instance { get; } = new ClassDeclarationOperator();


        private ClassDeclarationOperator()
        {
        }

        #endregion
    }
}


namespace R5T.L0073.F001.Raw
{
    public class ClassDeclarationOperator : IClassDeclarationOperator
    {
        #region Infrastructure

        public static IClassDeclarationOperator Instance { get; } = new ClassDeclarationOperator();


        private ClassDeclarationOperator()
        {
        }

        #endregion
    }
}
