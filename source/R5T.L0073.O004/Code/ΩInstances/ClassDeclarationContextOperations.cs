using System;


namespace R5T.L0073.O004
{
    public class ClassDeclarationContextOperations : IClassDeclarationContextOperations
    {
        #region Infrastructure

        public static IClassDeclarationContextOperations Instance { get; } = new ClassDeclarationContextOperations();


        private ClassDeclarationContextOperations()
        {
        }

        #endregion
    }
}
