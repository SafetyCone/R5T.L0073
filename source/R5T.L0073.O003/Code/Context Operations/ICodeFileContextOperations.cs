using System;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;

using R5T.L0073.T001;
using R5T.L0091.T000;
using R5T.L0092.T001;
using R5T.L0093.T000;
using R5T.T0241;


namespace R5T.L0073.O003
{
    [ContextOperationsMarker]
    public partial interface ICodeFileContextOperations : IContextOperationsMarker
    {
        public Func<TContext, Task> Write_CompilationUnit_ToFilePath<TContext>(
            out IChecked<IFileExists> codeFileExists)
            where TContext : IHasCompilationUnit, IHasFilePath
        {
            codeFileExists = Checked.Check<IFileExists>();

            return context =>
            {
                return Instances.CompilationUnitOperator.Write_ToFile(
                    context.CompilationUnit,
                    context.FilePath);
            };
        }

        public Func<TContext, Task> Write_SyntaxNode_ToFilePath<TContext, TSyntaxNode>(
            out IChecked<IFileExists> codeFileExists)
            where TContext : IHasSyntaxNode<TSyntaxNode>, IHasFilePath
            where TSyntaxNode : SyntaxNode
        {
            codeFileExists = Checked.Check<IFileExists>();

            return context =>
            {
                return Instances.SyntaxOperator._Platform.Write_ToFile(
                    context.SyntaxNode,
                    context.FilePath);
            };
        }
    }
}
