using System;


namespace R5T.L0073
{
    public class SyntaxGenerator : ISyntaxGenerator
    {
        #region Infrastructure

        public static ISyntaxGenerator Instance { get; } = new SyntaxGenerator();


        private SyntaxGenerator()
        {
        }

        #endregion
    }
}
