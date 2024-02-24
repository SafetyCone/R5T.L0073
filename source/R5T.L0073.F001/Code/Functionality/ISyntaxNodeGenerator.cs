using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.L0073.F001
{
    [FunctionalityMarker]
    public partial interface ISyntaxNodeGenerator : IFunctionalityMarker
    {
        /// <summary>
        /// Puts an XML documentation comment leading space into an XML text syntax element.
        /// </summary>
        public XmlTextSyntax XmlDocumentationCommentLeadingSpace()
        {
            var output = Instances.SyntaxGenerator.XmlText(
                // Tabination XML text literal would go here.
                Instances.SyntaxTokens.XmlDocumentationCommentLeadingSpace);

            return output;
        }

        /// <summary>
        /// Combines an XML text literal new line and an XML documentation comment leading space (which includes the XML documentation comment exterior trivia)
        /// into a single XML text syntax element.
        /// </summary>
        public XmlTextSyntax XmlDocumentationCommentLineLeadingSpace()
        {
            var output = Instances.SyntaxGenerator.XmlText(
                Instances.SyntaxTokens.XmlTextLiteralNewLine,
                // Tabination XML text literal would go here.
                Instances.SyntaxTokens.XmlDocumentationCommentLeadingSpace);

            return output;
        }
    }
}
