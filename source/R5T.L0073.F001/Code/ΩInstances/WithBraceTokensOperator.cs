using System;


namespace R5T.L0073.F001
{
    public class WithBraceTokensOperator : IWithBraceTokensOperator
    {
        #region Infrastructure

        public static IWithBraceTokensOperator Instance { get; } = new WithBraceTokensOperator();


        private WithBraceTokensOperator()
        {
        }

        #endregion
    }
}
