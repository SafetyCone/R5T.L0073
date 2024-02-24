using System;


namespace R5T.L0073.F001
{
    public class SyntaxTriviaOperations : ISyntaxTriviaOperations
    {
        #region Infrastructure

        public static ISyntaxTriviaOperations Instance { get; } = new SyntaxTriviaOperations();


        private SyntaxTriviaOperations()
        {
        }

        #endregion
    }
}
