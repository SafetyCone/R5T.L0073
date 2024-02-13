using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.L0073.T001;
using R5T.T0137;


namespace R5T.L0073.T003
{
    [ContextImplementationMarker]
    public class NamespaceDeclarationContext : IContextImplementationMarker,
        IWithCompilationUnit,
        IWithNamespaceDeclaration
    {
        public CompilationUnitSyntax CompilationUnit { get; set; }
        public NamespaceDeclarationSyntax NamespaceDeclaration { get; set; }
    }
}
