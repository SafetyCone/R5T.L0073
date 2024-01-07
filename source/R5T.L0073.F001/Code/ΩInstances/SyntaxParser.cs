using System;


namespace R5T.L0073.F001
{
    public class SyntaxParser : ISyntaxParser
    {
        #region Infrastructure

        public static ISyntaxParser Instance { get; } = new SyntaxParser();


        private SyntaxParser()
        {
        }

        #endregion
    }
}


namespace R5T.L0073.F001.Internal
{
    public class SyntaxParser : ISyntaxParser
    {
        #region Infrastructure

        public static ISyntaxParser Instance { get; } = new SyntaxParser();


        private SyntaxParser()
        {
        }

        #endregion
    }
}


namespace R5T.L0073.F001.Raw
{
    public class SyntaxParser : ISyntaxParser
    {
        #region Infrastructure

        public static ISyntaxParser Instance { get; } = new SyntaxParser();


        private SyntaxParser()
        {
        }

        #endregion
    }
}
