using System;


namespace R5T.L0073
{
    public class ExpressionStatements : IExpressionStatements
    {
        #region Infrastructure

        public static IExpressionStatements Instance { get; } = new ExpressionStatements();


        private ExpressionStatements()
        {
        }

        #endregion
    }
}
