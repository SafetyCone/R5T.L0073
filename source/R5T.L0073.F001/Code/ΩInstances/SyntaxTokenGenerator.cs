using System;


namespace R5T.L0073.F001
{
    public class SyntaxTokenGenerator : ISyntaxTokenGenerator
    {
        #region Infrastructure

        public static ISyntaxTokenGenerator Instance { get; } = new SyntaxTokenGenerator();


        private SyntaxTokenGenerator()
        {
        }

        #endregion
    }
}
