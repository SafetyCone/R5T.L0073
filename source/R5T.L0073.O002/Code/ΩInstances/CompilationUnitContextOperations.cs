using System;


namespace R5T.L0073.O002
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
