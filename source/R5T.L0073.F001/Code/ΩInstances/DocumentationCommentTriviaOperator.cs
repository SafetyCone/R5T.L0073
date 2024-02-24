using System;


namespace R5T.L0073.F001
{
    public class DocumentationCommentTriviaOperator : IDocumentationCommentTriviaOperator
    {
        #region Infrastructure

        public static IDocumentationCommentTriviaOperator Instance { get; } = new DocumentationCommentTriviaOperator();


        private DocumentationCommentTriviaOperator()
        {
        }

        #endregion
    }
}
