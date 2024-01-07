using System;


namespace R5T.L0073.F001
{
    public class SyntaxTriviaLists : ISyntaxTriviaLists
    {
        #region Infrastructure

        public static ISyntaxTriviaLists Instance { get; } = new SyntaxTriviaLists();


        private SyntaxTriviaLists()
        {
        }

        #endregion
    }
}
