using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0137;
using R5T.T0142;


namespace R5T.L0073.T002
{
    [ContextImplementationMarker, DataTypeMarker]
    public class CompilationUnitContext :
        ICompilationUnitContext
    {
        public CompilationUnitSyntax CompilationUnit { get; set; }
    }
}
