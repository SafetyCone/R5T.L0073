using System;


namespace R5T.L0073.F001
{
    public class SyntaxConstructors : ISyntaxConstructors
    {
        #region Infrastructure

        public static ISyntaxConstructors Instance { get; } = new SyntaxConstructors();


        private SyntaxConstructors()
        {
        }

        #endregion
    }
}
