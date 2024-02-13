using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.L0073.T001;
using R5T.L0096.T000;
using R5T.T0137;


namespace R5T.L0073.T003.N001
{
    [ContextImplementationMarker]
    public class NamespaceDeclarationContext : IContextImplementationMarker,
        IWithCompilationUnit,
        IWithNamespaceDeclaration,
        IWithNamespaceName
    {
        public CompilationUnitSyntax CompilationUnit { get; set; }
        public NamespaceDeclarationSyntax NamespaceDeclaration { get; set; }
        public string NamespaceName { get; set; }
    }
}
