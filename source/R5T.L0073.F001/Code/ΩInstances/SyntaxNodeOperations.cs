using System;


namespace R5T.L0073.F001
{
    public class SyntaxNodeOperations : ISyntaxNodeOperations
    {
        #region Infrastructure

        public static ISyntaxNodeOperations Instance { get; } = new SyntaxNodeOperations();


        private SyntaxNodeOperations()
        {
        }

        #endregion
    }
}
