using System;


namespace R5T.L0073.O002
{
    public class CompilationUnitContextConstructors : ICompilationUnitContextConstructors
    {
        #region Infrastructure

        public static ICompilationUnitContextConstructors Instance { get; } = new CompilationUnitContextConstructors();


        private CompilationUnitContextConstructors()
        {
        }

        #endregion
    }
}
