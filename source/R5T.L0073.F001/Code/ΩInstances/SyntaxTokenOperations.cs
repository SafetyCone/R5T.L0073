using System;


namespace R5T.L0073.F001
{
    public class SyntaxTokenOperations : ISyntaxTokenOperations
    {
        #region Infrastructure

        public static ISyntaxTokenOperations Instance { get; } = new SyntaxTokenOperations();


        private SyntaxTokenOperations()
        {
        }

        #endregion
    }
}
