using System;


namespace R5T.L0073.F001
{
    public class SyntaxTrivias : ISyntaxTrivias
    {
        #region Infrastructure

        public static ISyntaxTrivias Instance { get; } = new SyntaxTrivias();


        private SyntaxTrivias()
        {
        }

        #endregion
    }
}
