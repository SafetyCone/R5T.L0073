using System;


namespace R5T.L0073.O004
{
    public class DocumentationCommentContextOperations : IDocumentationCommentContextOperations
    {
        #region Infrastructure

        public static IDocumentationCommentContextOperations Instance { get; } = new DocumentationCommentContextOperations();


        private DocumentationCommentContextOperations()
        {
        }

        #endregion
    }
}
