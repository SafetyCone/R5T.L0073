using System;


namespace R5T.L0073.F001
{
    public class SyntaxElementOperator : ISyntaxElementOperator
    {
        #region Infrastructure

        public static ISyntaxElementOperator Instance { get; } = new SyntaxElementOperator();


        private SyntaxElementOperator()
        {
        }

        #endregion
    }
}
