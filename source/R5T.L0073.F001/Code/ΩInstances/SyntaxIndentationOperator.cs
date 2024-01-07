using System;


namespace R5T.L0073.F001
{
    public class SyntaxIndentationOperator : ISyntaxIndentationOperator
    {
        #region Infrastructure

        public static ISyntaxIndentationOperator Instance { get; } = new SyntaxIndentationOperator();


        private SyntaxIndentationOperator()
        {
        }

        #endregion
    }
}
