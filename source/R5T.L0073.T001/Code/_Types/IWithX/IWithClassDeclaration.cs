using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0240;


namespace R5T.L0073.T001
{
    [WithXMarker]
    public interface IWithClassDeclaration : IWithXMarker,
        IHasClassDeclaration,
        IWithSyntaxNode<ClassDeclarationSyntax>
    {
        new ClassDeclarationSyntax ClassDeclaration { get; set; }
    }
}
