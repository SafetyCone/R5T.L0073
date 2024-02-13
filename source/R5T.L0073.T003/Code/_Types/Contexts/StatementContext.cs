using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.L0073.T001;
using R5T.T0137;


namespace R5T.L0073.T003
{
    [ContextImplementationMarker]
    public class StatementContext : IContextImplementationMarker,
        IWithCompilationUnit,
        IWithNamespaceDeclaration,
        //IWithmem
        IWithMethodDeclaration,
        IWithStatement
    {
        public StatementSyntax Statement { get; set; }
        // Type.
        public MethodDeclarationSyntax MethodDeclaration { get; set; }
        public NamespaceDeclarationSyntax NamespaceDeclaration { get; set; }
        public CompilationUnitSyntax CompilationUnit { get; set; }
    }
}
