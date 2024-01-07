using System;


namespace R5T.L0073.F001
{
    public class SyntaxTriviaListOperator : ISyntaxTriviaListOperator
    {
        #region Infrastructure

        public static ISyntaxTriviaListOperator Instance { get; } = new SyntaxTriviaListOperator();


        private SyntaxTriviaListOperator()
        {
        }

        #endregion
    }
}
