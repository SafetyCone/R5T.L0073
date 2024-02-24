using System;


namespace R5T.L0073.F001
{
    public class SyntaxNodes : ISyntaxNodes
    {
        #region Infrastructure

        public static ISyntaxNodes Instance { get; } = new SyntaxNodes();


        private SyntaxNodes()
        {
        }

        #endregion
    }
}
