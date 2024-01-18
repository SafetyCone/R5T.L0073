using System;


namespace R5T.L0073.F002
{
    public class CompilationUnitOperator : ICompilationUnitOperator
    {
        #region Infrastructure

        public static ICompilationUnitOperator Instance { get; } = new CompilationUnitOperator();


        private CompilationUnitOperator()
        {
        }

        #endregion
    }
}
