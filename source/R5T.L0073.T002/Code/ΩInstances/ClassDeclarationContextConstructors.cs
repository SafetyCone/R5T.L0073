using System;


namespace R5T.L0073.T002
{
    public class ClassDeclarationContextConstructors : IClassDeclarationContextConstructors
    {
        #region Infrastructure

        public static IClassDeclarationContextConstructors Instance { get; } = new ClassDeclarationContextConstructors();


        private ClassDeclarationContextConstructors()
        {
        }

        #endregion
    }
}
