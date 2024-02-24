using System;


namespace R5T.L0073.F001
{
    public class XmlDocumentationCommentElementNames : IXmlDocumentationCommentElementNames
    {
        #region Infrastructure

        public static IXmlDocumentationCommentElementNames Instance { get; } = new XmlDocumentationCommentElementNames();


        private XmlDocumentationCommentElementNames()
        {
        }

        #endregion
    }
}
