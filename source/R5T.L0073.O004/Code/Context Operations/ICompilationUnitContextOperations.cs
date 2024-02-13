using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0221;
using R5T.T0241;

using R5T.L0073.T001;
using R5T.L0073.T003;
using R5T.L0096.T000;


namespace R5T.L0073.O004
{
    [ContextOperationsMarker]
    public partial interface ICompilationUnitContextOperations : IContextOperationsMarker
    {
        public Func<TContext, Task> In_NamespaceDeclarationContext<TContext>(
            out IsSet<IHasCompilationUnit> compilationUnitSet,
            IEnumerable<Func<NamespaceDeclarationContext, Task>> operations)
            where TContext : IWithCompilationUnit
        {
            return async context =>
            {
                var childContext = new NamespaceDeclarationContext
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

        public Func<TContext, Task> In_NamespaceDeclarationContext<TContext>(
            out IsSet<IHasCompilationUnit> compilationUnitSet,
            params Func<NamespaceDeclarationContext, Task>[] operations)
            where TContext : IWithCompilationUnit
        {
            return this.In_NamespaceDeclarationContext<TContext>(
                out compilationUnitSet,
                operations.AsEnumerable());
        }

        //public Func<TContext, Task> In_NamespaceDeclarationContext<TContext>(
        //    string namespaceName,
        //    out (IsSet<IHasCompilationUnit>, IsSet<IHasNamespaceDeclaration>) propertiesSet,
        //    out IChecked<IChildSyntaxElementAdded> namespaceDeclarationResultAdded,
        //    IEnumerable<Func<NamespaceDeclarationContext, Task>> operations)
        //    where TContext : IWithCompilationUnit
        //{
        //    namespaceDeclarationResultAdded = Checked.Check<IChildSyntaxElementAdded>();

        //    var modifiedOperations = operations.Append(
        //        Instances.NamespaceDeclarationContextOperations.Add_NamespaceDeclaration_ToCompilationUnit);

        //    return this.In_NamespaceDeclarationContext<TContext>(
        //        out _,
        //        modifiedOperations);
        //}

        //public Func<TContext, Task> In_NamespaceDeclarationContext<TContext>(
        //    string namespaceName,
        //    out (IsSet<IHasCompilationUnit>, IsSet<IHasNamespaceDeclaration>) propertiesSet,
        //    out IChecked<IChildSyntaxElementAdded> namespaceDeclarationResultAdded,
        //    params Func<NamespaceDeclarationContext, Task>[] operations)
        //    where TContext : IWithCompilationUnit
        //{
        //    return this.In_NamespaceDeclarationContext<TContext>(
        //        namespaceName,
        //        out propertiesSet,
        //        out namespaceDeclarationResultAdded,
        //        operations.AsEnumerable());
        //}

        public Func<TContext, Task> In_NamespaceDeclarationContext<TContext>(
            out (IsSet<IHasCompilationUnit>, IsSet<IHasNamespaceName>) propertiesSet,
            IEnumerable<Func<T003.N001.NamespaceDeclarationContext, Task>> operations)
            where TContext : IWithCompilationUnit, IHasNamespaceName
        {
            return async context =>
            {
                var childContext = new T003.N001.NamespaceDeclarationContext
                {
                    CompilationUnit = context.CompilationUnit,
                    NamespaceName = context.NamespaceName,
                };

                await Instances.ContextOperator.In_Context(
                    childContext,
                    operations);

                // Set the compilation unit in the parent context since the child context operations could have modified it.
                context.CompilationUnit = childContext.CompilationUnit;
            };
        }

        public Func<TContext, Task> In_NamespaceDeclarationContext<TContext>(
            out (IsSet<IHasCompilationUnit>, IsSet<IHasNamespaceName>) propertiesSet,
            params Func<T003.N001.NamespaceDeclarationContext, Task>[] operations)
            where TContext : IWithCompilationUnit, IHasNamespaceName
        {
            return this.In_NamespaceDeclarationContext<TContext>(
                out propertiesSet,
                operations.AsEnumerable());
        }
    }
}
