using System;


namespace R5T.L0073.F001
{
    public class SyntaxTokenOperator : ISyntaxTokenOperator
    {
        #region Infrastructure

        public static ISyntaxTokenOperator Instance { get; } = new SyntaxTokenOperator();


        private SyntaxTokenOperator()
        {
        }

        #endregion
    }
}


namespace R5T.L0073.F001.Raw
{
    public class SyntaxTokenOperator : ISyntaxTokenOperator
    {
        #region Infrastructure

        public static ISyntaxTokenOperator Instance { get; } = new SyntaxTokenOperator();


        private SyntaxTokenOperator()
        {
        }

        #endregion
    }
}
