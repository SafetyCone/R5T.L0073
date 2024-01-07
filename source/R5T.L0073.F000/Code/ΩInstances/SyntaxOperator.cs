using System;


namespace R5T.L0073.F000
{
    public class SyntaxOperator : ISyntaxOperator
    {
        #region Infrastructure

        public static ISyntaxOperator Instance { get; } = new SyntaxOperator();


        private SyntaxOperator()
        {
        }

        #endregion
    }
}
