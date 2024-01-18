using System;


namespace R5T.L0073.F002
{
    public class CompilationUnitOperations : ICompilationUnitOperations
    {
        #region Infrastructure

        public static ICompilationUnitOperations Instance { get; } = new CompilationUnitOperations();


        private CompilationUnitOperations()
        {
        }

        #endregion
    }
}
