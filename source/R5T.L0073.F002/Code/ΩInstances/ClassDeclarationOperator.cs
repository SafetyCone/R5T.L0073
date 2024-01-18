using System;


namespace R5T.L0073.F002
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
