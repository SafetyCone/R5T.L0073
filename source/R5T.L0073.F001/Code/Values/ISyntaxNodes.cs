using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.L0073.F001
{
    [ValuesMarker]
    public partial interface ISyntaxNodes : IValuesMarker
    {
        /// <inheritdoc cref="ISyntaxNodeGenerator.XmlDocumentationCommentLeadingSpace"/>
        public XmlTextSyntax XmlDocumentationCommentLeadingSpace => Instances.SyntaxNodeGenerator.XmlDocumentationCommentLeadingSpace();

        /// <inheritdoc cref="ISyntaxNodeGenerator.XmlDocumentationCommentLineLeadingSpace"/>
        public XmlTextSyntax XmlDocumentationCommentLineLeadingSpace => Instances.SyntaxNodeGenerator.XmlDocumentationCommentLineLeadingSpace();
    }
}
