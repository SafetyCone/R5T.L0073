using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0221;
using R5T.T0241;

using R5T.L0073.T001;
using R5T.L0073.T003;


namespace R5T.L0073.O004
{
    [ContextOperationsMarker]
    public partial interface IMethodDeclarationContextOperations : IContextOperationsMarker
    {
        public Func<TContext, Task> In_StatementDeclarationContext<TContext>(
            out (IsSet<IHasCompilationUnit>, IsSet<IHasNamespaceDeclaration>, IsSet<IHasMethodDeclaration>) propertiesSet,
            IEnumerable<Func<StatementContext, Task>> operations)
            where TContext : IWithCompilationUnit, IWithNamespaceDeclaration, IWithMethodDeclaration
        {
            return async context =>
            {
                var childContext = new StatementContext
                {
                    CompilationUnit = context.CompilationUnit,
                    NamespaceDeclaration = context.NamespaceDeclaration,
                    //ClassDeclaration = context.ClassDeclaration,
                    MethodDeclaration = context.MethodDeclaration,
                };

                await Instances.ContextOperator.In_Context(
                    childContext,
                    operations);

                context.MethodDeclaration = childContext.MethodDeclaration;
                context.NamespaceDeclaration = childContext.NamespaceDeclaration;
                context.CompilationUnit = childContext.CompilationUnit;
            };
        }

        public Func<TContext, Task> In_StatementDeclarationContext<TContext>(
            out (IsSet<IHasCompilationUnit>, IsSet<IHasNamespaceDeclaration>, IsSet<IHasMethodDeclaration>) propertiesSet,
            params Func<StatementContext, Task>[] operations)
            where TContext : IWithCompilationUnit, IWithNamespaceDeclaration, IWithMethodDeclaration
        {
            return this.In_StatementDeclarationContext<TContext>(
                out propertiesSet,
                operations.AsEnumerable());
        }
    }
}
