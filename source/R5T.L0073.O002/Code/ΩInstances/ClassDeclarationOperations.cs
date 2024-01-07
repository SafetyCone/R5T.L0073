using System;


namespace R5T.L0073.O002
{
    public class ClassDeclarationOperations : IClassDeclarationOperations
    {
        #region Infrastructure

        public static IClassDeclarationOperations Instance { get; } = new ClassDeclarationOperations();


        private ClassDeclarationOperations()
        {
        }

        #endregion
    }
}
