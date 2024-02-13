using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.L0073.T001;
using R5T.L0093.T000;
using R5T.L0096.T000;
using R5T.T0137;


namespace R5T.L0073.T003
{
    [ContextImplementationMarker]
    public class CompilationFileContext : IContextImplementationMarker,
        IWithFilePath,
        IWithCompilationUnit,
        IWithNamespaceName
    {
        public string FilePath { get; set; }
        public CompilationUnitSyntax CompilationUnit { get; set; }
        public string NamespaceName { get; set; }
    }
}
