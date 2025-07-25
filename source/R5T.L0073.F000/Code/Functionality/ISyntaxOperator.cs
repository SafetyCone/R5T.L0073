using System;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;

using R5T.T0132;
using R5T.T0172;


namespace R5T.L0073.F000
{
    [FunctionalityMarker]
    public partial interface ISyntaxOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public F001.ISyntaxOperator _Platform => F001.SyntaxOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public Task Write_ToFile(
            SyntaxNode syntaxNode,
            ICodeFilePath codeFilePath,
            bool overwrite = L0066.IValues.Overwrite_Default_Constant)
        {
            return Instances.FileOperator.Write_ToFile_FromIntermediateMemoryStream(
                codeFilePath,
                syntaxNode.WriteTo,
                overwrite);
        }

        public void Write_ToFile_Synchronous(
            SyntaxNode syntaxNode,
            ICodeFilePath codeFilePath,
            bool overwrite = L0066.IValues.Overwrite_Default_Constant)
        {
            using var fileWriter = Instances.FileOperator.Open_ForWrite(codeFilePath);

            syntaxNode.WriteTo(fileWriter);
        }

        public Task Write_ToFile(
            SyntaxToken syntaxToken,
            ICodeFilePath codeFilePath,
            bool overwrite = L0066.IValues.Overwrite_Default_Constant)
        {
            return Instances.FileOperator.Write_ToFile_FromIntermediateMemoryStream(
                codeFilePath,
                syntaxToken.WriteTo,
                overwrite);
        }

        public void Write_ToFile_Synchronous(
            SyntaxToken syntaxToken,
            ICodeFilePath codeFilePath,
            bool overwrite = L0066.IValues.Overwrite_Default_Constant)
        {
            using var fileWriter = Instances.FileOperator.Open_ForWrite(codeFilePath);

            syntaxToken.WriteTo(fileWriter);
        }

        public Task Write_ToFile(
            SyntaxTrivia syntaxTrivia,
            ICodeFilePath codeFilePath,
            bool overwrite = L0066.IValues.Overwrite_Default_Constant)
        {
            return Instances.FileOperator.Write_ToFile_FromIntermediateMemoryStream(
                codeFilePath,
                syntaxTrivia.WriteTo,
                overwrite);
        }

        public void Write_ToFile_Synchronous(
            SyntaxTrivia syntaxTrivia,
            ICodeFilePath codeFilePath,
            bool overwrite = L0066.IValues.Overwrite_Default_Constant)
        {
            using var fileWriter = Instances.FileOperator.Open_ForWrite(codeFilePath);

            syntaxTrivia.WriteTo(fileWriter);
        }
    }
}
