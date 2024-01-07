using System;


namespace R5T.L0073.F001
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


namespace R5T.L0073.F001.Raw
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
