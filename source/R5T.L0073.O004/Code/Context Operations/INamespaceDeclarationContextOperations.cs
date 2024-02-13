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
    public partial interface INamespaceDeclarationContextOperations : IContextOperationsMarker
    {
        public Func<TContext, Task> In_ClassDeclarationContext<TContext>(
            out (IsSet<IHasCompilationUnit>, IsSet<IHasNamespaceDeclaration>) propertiesSet,
            IEnumerable<Func<ClassDeclarationContext, Task>> operations)
            where TContext : IWithCompilationUnit, IWithNamespaceDeclaration
        {
            return async context =>
            {
                var childContext = new ClassDeclarationContext
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

        public Func<TContext, Task> In_ClassDeclarationContext<TContext>(
            out (IsSet<IHasCompilationUnit>, IsSet<IHasNamespaceDeclaration>) propertiesSet,
            params Func<ClassDeclarationContext, Task>[] operations)
            where TContext : IWithCompilationUnit, IWithNamespaceDeclaration
        {
            return this.In_ClassDeclarationContext<TContext>(
                out propertiesSet,
                operations.AsEnumerable());
        }
    }
}
