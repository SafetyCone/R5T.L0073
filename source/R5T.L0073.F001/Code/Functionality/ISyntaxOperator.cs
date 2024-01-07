using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;

using R5T.T0132;


namespace R5T.L0073.F001
{
    [FunctionalityMarker]
    public partial interface ISyntaxOperator : IFunctionalityMarker
    {
        public TNode Modify<TNode>(
            TNode node,
            IEnumerable<Func<TNode, TNode>> modifiers)
        {
            var output = Instances.FunctionOperator.Run_Modifiers(
                node,
                modifiers);

            return output;
        }

        public TNode Prepend_BlankLine<TNode>(TNode node)
            where TNode : SyntaxNode
        {
            var output = Instances.SyntaxNodeOperator.Prepend_BlankLine(node);
            return output;
        }

        public TNode Prepend_NewLine<TNode>(TNode node)
            where TNode : SyntaxNode
        {
            var output = Instances.SyntaxNodeOperator.Prepend_NewLine(node);
            return output;
        }

        public SyntaxToken Prepend_Space(SyntaxToken token)
        {
            var output = Instances.SyntaxTokenOperator.Prepend_Space(token);
            return output;
        }

        public TNode Prepend_Space<TNode>(TNode node)
            where TNode : SyntaxNode
        {
            var output = Instances.SyntaxNodeOperator.Prepend_Space(node);
            return output;
        }

        public TNode Prepend_TwoBlankLines<TNode>(TNode node)
            where TNode : SyntaxNode
        {
            var output = Instances.SyntaxNodeOperator.Prepend_TwoBlankLines(node);
            return output;
        }

        public TNode Remove_LeadingTrivia<TNode>(TNode node)
            where TNode : SyntaxNode
        {
            var output = Instances.SyntaxNodeOperator.Remove_LeadingTrivia(node);
            return output;
        }

        public Task Write_ToFile(
            SyntaxNode syntaxNode,
            string codeFilePath,
            bool overwrite = L0066.IValues.Default_OverwriteValue_Constant)
        {
            return Instances.FileOperator.Write_ToFile_FromIntermediateMemoryStream(
                codeFilePath,
                syntaxNode.WriteTo,
                overwrite);
        }

        public void Write_ToFile_Synchronous(
            SyntaxNode syntaxNode,
            string codeFilePath,
            bool overwrite = L0066.IValues.Default_OverwriteValue_Constant)
        {
            using var fileWriter = Instances.FileOperator.Open_ForWrite(codeFilePath);

            syntaxNode.WriteTo(fileWriter);
        }

        public Task Write_ToFile(
            SyntaxToken syntaxToken,
            string codeFilePath,
            bool overwrite = L0066.IValues.Default_OverwriteValue_Constant)
        {
            return Instances.FileOperator.Write_ToFile_FromIntermediateMemoryStream(
                codeFilePath,
                syntaxToken.WriteTo,
                overwrite);
        }

        public void Write_ToFile_Synchronous(
            SyntaxToken syntaxToken,
            string codeFilePath,
            bool overwrite = L0066.IValues.Default_OverwriteValue_Constant)
        {
            using var fileWriter = Instances.FileOperator.Open_ForWrite(codeFilePath);

            syntaxToken.WriteTo(fileWriter);
        }

        public Task Write_ToFile(
            SyntaxTrivia syntaxTrivia,
            string codeFilePath,
            bool overwrite = L0066.IValues.Default_OverwriteValue_Constant)
        {
            return Instances.FileOperator.Write_ToFile_FromIntermediateMemoryStream(
                codeFilePath,
                syntaxTrivia.WriteTo,
                overwrite);
        }

        public void Write_ToFile_Synchronous(
            SyntaxTrivia syntaxTrivia,
            string codeFilePath,
            bool overwrite = L0066.IValues.Default_OverwriteValue_Constant)
        {
            using var fileWriter = Instances.FileOperator.Open_ForWrite(codeFilePath);

            syntaxTrivia.WriteTo(fileWriter);
        }
    }
}
