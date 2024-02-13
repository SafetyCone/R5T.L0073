using System;


namespace R5T.L0073.O003
{
    public class CodeFileContextOperations : ICodeFileContextOperations
    {
        #region Infrastructure

        public static ICodeFileContextOperations Instance { get; } = new CodeFileContextOperations();


        private CodeFileContextOperations()
        {
        }

        #endregion
    }
}
