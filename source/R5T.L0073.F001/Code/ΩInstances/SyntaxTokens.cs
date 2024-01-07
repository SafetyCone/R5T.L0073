using System;


namespace R5T.L0073.F001
{
    public class SyntaxTokens : ISyntaxTokens
    {
        #region Infrastructure

        public static ISyntaxTokens Instance { get; } = new SyntaxTokens();


        private SyntaxTokens()
        {
        }

        #endregion
    }
}
