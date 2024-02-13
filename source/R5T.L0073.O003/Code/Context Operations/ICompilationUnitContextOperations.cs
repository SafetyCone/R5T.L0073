using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.L0091.T000;
using R5T.T0221;
using R5T.T0241;

using R5T.L0073.T001;
using R5T.L0073.T004;
using R5T.L0092.T001;
using R5T.L0093.T000;


namespace R5T.L0073.O003
{
    [ContextOperationsMarker]
    public partial interface ICompilationUnitContextOperations : IContextOperationsMarker
    {
        public Task Add_NamespaceDeclaration_ToCompilationUnit<TContext>(TContext context)
            where TContext : IWithCompilationUnit, IHasNamespaceDeclaration
        {
            context.CompilationUnit = Instances.CompilationUnitOperator.Add_Namespace(
                context.CompilationUnit,
                context.NamespaceDeclaration);

            return Task.CompletedTask;
        }

        public Func<TContext, Task> Add_UsingNamespace<TContext>(
            string namespaceName,
            out IChecked<IUsingNamespace> usingNamespaceChecked)
            where TContext : IWithCompilationUnit
        {
            usingNamespaceChecked = Checked.Check<IUsingNamespace>();

            return context =>
            {
                context.CompilationUnit = Instances.CompilationUnitOperator.Add_UsingDirective(
                    context.CompilationUnit,
                    namespaceName);

                return Task.CompletedTask;
            };
        }

        public Func<TContext, Task> In_NamespaceDeclarationContext<TContext, TNamespaceDeclarationContext>(
            out IsSet<IHasCompilationUnit> compilationUnitSet,
            IEnumerable<Func<TNamespaceDeclarationContext, Task>> operations)
            where TContext : IWithCompilationUnit
            where TNamespaceDeclarationContext : IWithCompilationUnit, new()
        {
            return async context =>
            {
                var childContext = new TNamespaceDeclarationContext
                {
                    CompilationUnit = context.CompilationUnit
                };

                await Instances.ContextOperator.In_Context(
                    childContext,
                    operations);

                // Set the compilation unit in the parent context since the child context operations could have modified it.
                context.CompilationUnit = childContext.CompilationUnit;
            };
        }

        public Func<TContext, Task> In_NamespaceDeclarationContext<TContext, TNamespaceDeclarationContext>(
            out IsSet<IHasCompilationUnit> compilationUnitSet,
            params Func<TNamespaceDeclarationContext, Task>[] operations)
            where TContext : IWithCompilationUnit
            where TNamespaceDeclarationContext : IWithCompilationUnit, new()
        {
            return this.In_NamespaceDeclarationContext<TContext, TNamespaceDeclarationContext>(
                out compilationUnitSet,
                operations.AsEnumerable());
        }

        public Task Set_CompilationUnit_ToNewEmpty<TContext>(TContext context)
            where TContext : IWithCompilationUnit
        {
            context.CompilationUnit = Instances.CompilationUnitOperator.New_Empty();

            return Task.CompletedTask;
        }

        public Func<TContext, Task> Write_CompilationUnit_ToFilePath<TContext>(
            out IChecked<IFileExists> codeFileExists)
            where TContext : IHasCompilationUnit, IHasFilePath
        {
            return Instances.CodeFileContextOperations.Write_CompilationUnit_ToFilePath<TContext>(
                out codeFileExists);
        }
    }
}
