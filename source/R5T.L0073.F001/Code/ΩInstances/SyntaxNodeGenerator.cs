using System;


namespace R5T.L0073.F001
{
    public class SyntaxNodeGenerator : ISyntaxNodeGenerator
    {
        #region Infrastructure

        public static ISyntaxNodeGenerator Instance { get; } = new SyntaxNodeGenerator();


        private SyntaxNodeGenerator()
        {
        }

        #endregion
    }
}
