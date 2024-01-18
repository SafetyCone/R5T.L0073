using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;

using R5T.L0073.T001;


namespace R5T.L0073.F002
{
    [FunctionalityMarker]
    public partial interface ISyntaxGenerator : IFunctionalityMarker,
        F001.ISyntaxGenerator
    {
        public CompilationUnitSyntax Create_CompilationUnit<TCompilationUnitContext>(
            Func<CompilationUnitSyntax, TCompilationUnitContext> compilationUnitContextConstructor,
            IEnumerable<Action<TCompilationUnitContext>> compilationUnitContextActions)
            where TCompilationUnitContext : IHasCompilationUnit
        {
            var compilationUnit = this.CompilationUnit();

            var compilationUnitContext = compilationUnitContextConstructor(compilationUnit);

            Instances.ContextOperator.In_Context(
                compilationUnitContext,
                compilationUnitContextActions);

            var output = compilationUnitContext.CompilationUnit;
            return output;
        }

        public CompilationUnitSyntax Create_CompilationUnit<TCompilationUnitContext>(
            Func<CompilationUnitSyntax, TCompilationUnitContext> compilationUnitContextConstructor,
            params Action<TCompilationUnitContext>[] compilationUnitContextActions)
            where TCompilationUnitContext : IHasCompilationUnit
        {
            return this.Create_CompilationUnit(
                compilationUnitContextConstructor,
                compilationUnitContextActions.AsEnumerable());
        }
    }
}
