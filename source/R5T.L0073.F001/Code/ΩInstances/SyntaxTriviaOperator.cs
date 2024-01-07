using System;


namespace R5T.L0073.F001
{
    public class SyntaxTriviaOperator : ISyntaxTriviaOperator
    {
        #region Infrastructure

        public static ISyntaxTriviaOperator Instance { get; } = new SyntaxTriviaOperator();


        private SyntaxTriviaOperator()
        {
        }

        #endregion
    }
}
