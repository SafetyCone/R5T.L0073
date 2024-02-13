using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.L0073.T001;
using R5T.L0096.T000;
using R5T.T0221;
using R5T.T0241;


namespace R5T.L0073.O003
{
    [ContextOperationsMarker]
    public partial interface INamespaceDeclarationContextOperations : IContextOperationsMarker
    {
        public Task Add_ClassDeclaration_ToNamespaceDeclaration<TContext>(TContext context)
            where TContext : IWithNamespaceDeclaration, IHasClassDeclaration
        {
            context.NamespaceDeclaration = Instances.NamespaceDeclarationOperator.Add_Class(
                context.NamespaceDeclaration,
                context.ClassDeclaration);

            return Task.CompletedTask;
        }

        public Task Add_NamespaceDeclaration_ToCompilationUnit<TContext>(TContext context)
            where TContext : IWithCompilationUnit, IHasNamespaceDeclaration
        {
            return Instances.CompilationUnitContextOperations.Add_NamespaceDeclaration_ToCompilationUnit(context);
        }

        public Func<TContext, Task> In_ClassDeclarationContext<TContext, TClassDeclarationContext>(
            out (IsSet<IHasCompilationUnit>, IsSet<IHasNamespaceDeclaration>) propertiesSet,
            IEnumerable<Func<TClassDeclarationContext, Task>> operations)
            where TContext : IWithCompilationUnit, IWithNamespaceDeclaration
            where TClassDeclarationContext : IWithCompilationUnit, IWithNamespaceDeclaration, new()
        {
            return async context =>
            {
                var childContext = new TClassDeclarationContext
                {
                    CompilationUnit = context.CompilationUnit,
                    NamespaceDeclaration = context.NamespaceDeclaration,
                };

                await Instances.ContextOperator.In_Context(
                    childContext,
                    operations);

                // Set the compilation unit in the parent context since the child context operations could have modified it.
                context.CompilationUnit = childContext.CompilationUnit;
                context.NamespaceDeclaration = childContext.NamespaceDeclaration;
            };
        }

        public Func<TContext, Task> In_ClassDeclarationContext<TContext, TClassDeclarationContext>(
            out (IsSet<IHasCompilationUnit>, IsSet<IHasNamespaceDeclaration>) propertiesSet,
            params Func<TClassDeclarationContext, Task>[] operations)
            where TContext : IWithCompilationUnit, IWithNamespaceDeclaration
            where TClassDeclarationContext : IWithCompilationUnit, IWithNamespaceDeclaration, new()
        {
            return this.In_ClassDeclarationContext<TContext, TClassDeclarationContext>(
                out propertiesSet,
                operations.AsEnumerable());
        }

        public Func<TContext, Task> Set_NamespaceDeclaration_ToNewEmpty<TContext>(
            string namespaceName,
            out IsSet<IHasNamespaceDeclaration> namespaceDeclarationSet)
            where TContext : IWithNamespaceDeclaration
        {
            return context =>
            {
                context.NamespaceDeclaration = Instances.SyntaxGenerator.Namespace(
                    namespaceName);

                return Task.CompletedTask;
            };
        }

        public Func<TContext, Task> Set_NamespaceDeclaration_ToNewEmpty<TContext>(
            out IsSet<IHasNamespaceDeclaration> namespaceDeclarationSet)
            where TContext : IWithNamespaceDeclaration, IHasNamespaceName
        {
            return context =>
            {
                context.NamespaceDeclaration = Instances.SyntaxGenerator.Namespace(
                    context.NamespaceName);

                return Task.CompletedTask;
            };
        }
    }
}
