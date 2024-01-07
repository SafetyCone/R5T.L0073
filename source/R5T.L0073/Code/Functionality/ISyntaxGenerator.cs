using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.L0073
{
    [FunctionalityMarker]
    public partial interface ISyntaxGenerator : IFunctionalityMarker,
        F001.ISyntaxGenerator
    {
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
                    Instances.CompilationUnitOperations.Add_UsingDirective(
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
