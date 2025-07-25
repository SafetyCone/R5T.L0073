using System;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;
using R5T.T0172;


namespace R5T.L0073.F000
{
    [FunctionalityMarker]
    public partial interface ICompilationUnitOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public F001.ICompilationUnitOperator _Platform => F001.CompilationUnitOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public Task<CompilationUnitSyntax> Load(ICodeFilePath codeFilePath)
        {
            return _Platform.Load(codeFilePath.Value);
        }

        public CompilationUnitSyntax Load_Synchronous(ICodeFilePath codeFilePath)
        {
            return _Platform.Load_Synchronous(codeFilePath.Value);
        }

        public Task<CompilationUnitSyntax> Load_Raw(ICodeFilePath codeFilePath)
        {
            return _Platform.Load_Raw(codeFilePath.Value);
        }

        public CompilationUnitSyntax Load_Raw_Synchronous(ICodeFilePath codeFilePath)
        {
            return _Platform.Load_Raw_Synchronous(codeFilePath.Value);
        }

        /// <summary>
        /// Gets a brand new, empty, compilation unit.
        /// </summary>
        /// <remarks>
        /// Quality-of-life overload for <see cref="New"/>.
        /// </remarks>
        public CompilationUnitSyntax New_Empty()
        {
            var output = this.New();
            return output;
        }

        /// <summary>
        /// Gets a brand new compilation unit.
        /// </summary>
        /// <returns></returns>
        public CompilationUnitSyntax New()
        {
            var output = Instances.SyntaxGenerator.CompilationUnit();
            return output;
        }

        public Task Write_ToFile(
            CompilationUnitSyntax compilationUnit,
            ICodeFilePath codeFilePath,
            bool overwrite = L0066.IValues.Overwrite_Default_Constant)
        {
            return _Platform.Write_ToFile(
                compilationUnit,
                codeFilePath.Value,
                overwrite);
        }

        public void Write_ToFile_Synchronous(
            CompilationUnitSyntax compilationUnit,
            ICodeFilePath codeFilePath,
            bool overwrite = L0066.IValues.Overwrite_Default_Constant)
        {
            _Platform.Write_ToFile_Synchronous(
                compilationUnit,
                codeFilePath.Value,
                overwrite);
        }
    }
}
