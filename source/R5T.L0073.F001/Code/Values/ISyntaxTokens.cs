using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using R5T.T0131;


namespace R5T.L0073.F001
{
    [ValuesMarker]
    public partial interface ISyntaxTokens : IValuesMarker
    {
        /// <summary>
        /// <para><value>async</value></para>
        /// </summary>
        public SyntaxToken Async_Keyword => Instances.SyntaxTokenGenerator.Async_Keyword();

        /// <summary>
        /// The initial syntax token.
        /// (Straight out of the constructor.)
        /// </summary>
        public SyntaxToken Initial => Instances.SyntaxTokenOperator.New();

        /// <summary>
        /// <para><value>private</value></para>
        /// </summary>
        public SyntaxToken Private_Keyword => Instances.SyntaxTokenGenerator.Private_Keyword();

        /// <summary>
        /// <para><value>public</value></para>
        /// </summary>
        public SyntaxToken Public_Keyword => Instances.SyntaxTokenGenerator.Public_Keyword();

        /// <summary>
        /// <para><value>static</value></para>
        /// </summary>
        public SyntaxToken Static_Keyword => Instances.SyntaxTokenGenerator.Static_Keyword();

        public SyntaxToken String => Instances.SyntaxTokenGenerator.Keyword(SyntaxKind.StringKeyword);

        public SyntaxToken Var => Instances.SyntaxTokenGenerator.Keyword(SyntaxKind.VarKeyword);

        public SyntaxToken Void => Instances.SyntaxTokenGenerator.Keyword(SyntaxKind.VoidKeyword);

        /// <inheritdoc cref="ISyntaxTokenGenerator.XmlDocumentationCommentLeadingSpace"/>
        public SyntaxToken XmlDocumentationCommentLeadingSpace => Instances.SyntaxTokenGenerator.XmlDocumentationCommentLeadingSpace();

        /// <inheritdoc cref="ISyntaxGenerator.XmlTextLiteralNewLine"/>
        public SyntaxToken XmlTextLiteralNewLine => Instances.SyntaxGenerator.XmlTextLiteralNewLine();
    }
}
