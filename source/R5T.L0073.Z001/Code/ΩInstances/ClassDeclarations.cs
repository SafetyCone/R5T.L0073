using System;


namespace R5T.L0073.Z001
{
    public class ClassDeclarations : IClassDeclarations
    {
        #region Infrastructure

        public static IClassDeclarations Instance { get; } = new ClassDeclarations();


        private ClassDeclarations()
        {
        }

        #endregion
    }
}


namespace R5T.L0073.Z001.Empty
{
    public class ClassDeclarations : IClassDeclarations
    {
        #region Infrastructure

        public static IClassDeclarations Instance { get; } = new ClassDeclarations();


        private ClassDeclarations()
        {
        }

        #endregion
    }
}
