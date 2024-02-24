using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0240;


namespace R5T.L0073.T001
{
    /// <summary>
    /// Indicates a context has a Roslyn-based XML documentation comment instance.
    /// </summary>
    [HasXMarker]
    public interface IHasDocumentationComment : IHasXMarker
        // Do NOT have this inheritance!
        //IHasSyntaxNode<DocumentationCommentTriviaSyntax>
    {
        DocumentationCommentTriviaSyntax DocumentationComment { get; }
    }
}
