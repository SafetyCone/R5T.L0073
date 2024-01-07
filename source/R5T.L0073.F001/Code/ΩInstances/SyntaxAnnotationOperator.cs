using System;


namespace R5T.L0073.F001
{
    public class SyntaxAnnotationOperator : ISyntaxAnnotationOperator
    {
        #region Infrastructure

        public static ISyntaxAnnotationOperator Instance { get; } = new SyntaxAnnotationOperator();


        private SyntaxAnnotationOperator()
        {
        }

        #endregion
    }
}
