using System;


namespace R5T.L0073.F001
{
    public class TypeDeclarationOperator : ITypeDeclarationOperator
    {
        #region Infrastructure

        public static ITypeDeclarationOperator Instance { get; } = new TypeDeclarationOperator();


        private TypeDeclarationOperator()
        {
        }

        #endregion
    }
}
