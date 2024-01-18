using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;

using R5T.L0073.T002;


namespace R5T.L0073.O002
{
    [ValuesMarker]
    public partial interface ICompilationUnitContextConstructors : IValuesMarker
    {
        public ICompilationUnitContext New_CompilationUnitContext(
            CompilationUnitSyntax compilationUnit)
        {
            var compilationUnitContext = new CompilationUnitContext
            {
                CompilationUnit = compilationUnit
            };

            return compilationUnitContext;
        }
    }
}
