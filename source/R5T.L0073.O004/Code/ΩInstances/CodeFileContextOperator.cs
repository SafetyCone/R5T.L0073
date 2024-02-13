using System;


namespace R5T.L0073.O004
{
    public class CodeFileContextOperator : ICodeFileContextOperator
    {
        #region Infrastructure

        public static ICodeFileContextOperator Instance { get; } = new CodeFileContextOperator();


        private CodeFileContextOperator()
        {
        }

        #endregion
    }
}
