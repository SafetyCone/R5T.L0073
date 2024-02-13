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
    public partial interface IClassDeclarationContextOperations : IContextOperationsMarker
    {
        public Func<TContext, Task> In_MethodDeclarationContext<TContext>(
            out (IsSet<IHasCompilationUnit>, IsSet<IHasNamespaceDeclaration>, IsSet<IHasClassDeclaration>, IsSet<IHasMemberDeclaration>) propertiesSet,
            IEnumerable<Func<MethodDeclarationContext, Task>> operations)
            where TContext : IWithCompilationUnit, IWithNamespaceDeclaration, IWithClassDeclaration
        {
            return async context =>
            {
                var childContext = new MethodDeclarationContext
                {
                    CompilationUnit = context.CompilationUnit,
                    NamespaceDeclaration = context.NamespaceDeclaration,
                    ClassDeclaration = context.ClassDeclaration,
                };

                await Instances.ContextOperator.In_Context(
                    childContext,
                    operations);

                context.ClassDeclaration = childContext.ClassDeclaration;
                context.NamespaceDeclaration = childContext.NamespaceDeclaration;
                context.CompilationUnit = childContext.CompilationUnit;
            };
        }

        public Func<TContext, Task> In_MethodDeclarationContext<TContext>(
            out (IsSet<IHasCompilationUnit>, IsSet<IHasNamespaceDeclaration>, IsSet<IHasClassDeclaration>, IsSet<IHasMemberDeclaration>) propertiesSet,
            params Func<MethodDeclarationContext, Task>[] operations)
            where TContext : IWithCompilationUnit, IWithNamespaceDeclaration, IWithClassDeclaration
        {
            return this.In_MethodDeclarationContext<TContext>(
                out propertiesSet,
                operations.AsEnumerable());
        }
    }
}
