using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0142;


namespace R5T.L0073.T001
{
    [DataTypeMarker]
    public interface IHasNamespaceDeclaration
    {
        NamespaceDeclarationSyntax NamespaceDeclaration { get; }
    }
}
