using System;


namespace R5T.L0073.F001
{
    public class SyntaxTokenListOperator : ISyntaxTokenListOperator
    {
        #region Infrastructure

        public static ISyntaxTokenListOperator Instance { get; } = new SyntaxTokenListOperator();


        private SyntaxTokenListOperator()
        {
        }

        #endregion
    }
}
