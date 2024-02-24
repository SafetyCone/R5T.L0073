using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.L0073.F001
{
    [FunctionalityMarker]
    public partial interface IDocumentationCommentTriviaOperator : IFunctionalityMarker
    {
        public DocumentationCommentTriviaSyntax Add_Contents(
            DocumentationCommentTriviaSyntax documentationCommentTriviaSyntax,
            IEnumerable<XmlNodeSyntax> contents)
        {
            var contentsArray = contents.ToArray();

            var output = this.Add_Contents(
                documentationCommentTriviaSyntax,
                contentsArray);

            return output;
        }

        public DocumentationCommentTriviaSyntax Add_Contents(
            DocumentationCommentTriviaSyntax documentationCommentTriviaSyntax,
            params XmlNodeSyntax[] contents)
        {
            var output = documentationCommentTriviaSyntax
                .AddContent(contents);

            return output;
        }
    }
}
