using System;


namespace R5T.L0073.O003
{
    public class StatementContextOperations : IStatementContextOperations
    {
        #region Infrastructure

        public static IStatementContextOperations Instance { get; } = new StatementContextOperations();


        private StatementContextOperations()
        {
        }

        #endregion
    }
}
