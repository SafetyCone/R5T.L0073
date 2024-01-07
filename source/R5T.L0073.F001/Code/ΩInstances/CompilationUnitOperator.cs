using System;


namespace R5T.L0073.F001
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


namespace R5T.L0073.F001.Raw
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
