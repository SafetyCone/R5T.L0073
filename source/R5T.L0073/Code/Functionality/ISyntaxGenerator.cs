using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;

using R5T.L0073.T001;
using R5T.L0073.T002;


namespace R5T.L0073
{
    [FunctionalityMarker]
    public partial interface ISyntaxGenerator : IFunctionalityMarker,
        F001.ISyntaxGenerator,
        F002.ISyntaxGenerator
    {
        new public CompilationUnitSyntax Create_CompilationUnit<TCompilationUnitContext>(
            Func<CompilationUnitSyntax, TCompilationUnitContext> compilationUnitContextConstructor,
            IEnumerable<Action<TCompilationUnitContext>> compilationUnitContextActions)
            where TCompilationUnitContext : IWithCompilationUnit
        {
            var modifiedCompilationUnitContextActions = compilationUnitContextActions.Prepend(
                Instances.CompilationUnitOperations.Add_UsingDirective<TCompilationUnitContext>(
                    Instances.UsingDirectives.System
                )
            );

            return (this as F002.ISyntaxGenerator).Create_CompilationUnit(
                compilationUnitContextConstructor,
                modifiedCompilationUnitContextActions);
        }

        new public CompilationUnitSyntax Create_CompilationUnit<TCompilationUnitContext>(
            Func<CompilationUnitSyntax, TCompilationUnitContext> compilationUnitContextConstructor,
            params Action<TCompilationUnitContext>[] compilationUnitContextActions)
            where TCompilationUnitContext : IWithCompilationUnit
        {
            return this.Create_CompilationUnit(
                compilationUnitContextConstructor,
                compilationUnitContextActions.AsEnumerable());
        }

        public CompilationUnitSyntax Create_CompilationUnit(IEnumerable<Action<ICompilationUnitContext>> compilationUnitContextActions)
        {
            var output = this.Create_CompilationUnit(
                Instances.CompilationUnitContextConstructors.New_CompilationUnitContext,
                compilationUnitContextActions);

            return output;
        }

        public CompilationUnitSyntax Create_CompilationUnit(params Action<ICompilationUnitContext>[] compilationUnitContextActions)
        {
            return this.Create_CompilationUnit(compilationUnitContextActions.AsEnumerable());
        }

        /// <summary>
        /// Provides a compilation unit that includes the System using directive.
        /// </summary>
        new public CompilationUnitSyntax Create_CompilationUnit(
            IEnumerable<Func<CompilationUnitSyntax, CompilationUnitSyntax>> modifiers)
        {
            var compilationUnit = this.CompilationUnit();

            var output = this.Build(
                compilationUnit,
                modifiers.Prepend(
                    Instances.CompilationUnitOperations_F001.Add_UsingDirective(
                        Instances.UsingDirectives.System
                    )
                )
            );

            return output;
        }

        /// <inheritdoc cref="Create_CompilationUnit(IEnumerable{Func{CompilationUnitSyntax, CompilationUnitSyntax}})"/>
        new public CompilationUnitSyntax Create_CompilationUnit(
            params Func<CompilationUnitSyntax, CompilationUnitSyntax>[] modifiers)
        {
            return this.Create_CompilationUnit(
                modifiers.AsEnumerable());
        }
    }
}
