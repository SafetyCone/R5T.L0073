using System;


namespace R5T.L0073.O003
{
    public class CompilationUnitContextOperations : ICompilationUnitContextOperations
    {
        #region Infrastructure

        public static ICompilationUnitContextOperations Instance { get; } = new CompilationUnitContextOperations();


        private CompilationUnitContextOperations()
        {
        }

        #endregion
    }
}
