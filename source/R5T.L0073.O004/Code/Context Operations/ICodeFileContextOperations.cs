using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.L0073.T003;
using R5T.L0093.T000;
using R5T.L0096.T000;
using R5T.T0221;
using R5T.T0241;


namespace R5T.L0073.O004
{
    [ContextOperationsMarker]
    public partial interface ICodeFileContextOperations : IContextOperationsMarker
    {
        public Func<TContext, Task> In_CompilationFileContext<TContext>(
            out (IsSet<IHasFilePath>, IsSet<IHasNamespaceName>) propertiesSet,
            IEnumerable<Func<CompilationFileContext, Task>> operations)
            where TContext : IHasFilePath, IHasNamespaceName
        {
            return context =>
            {
                var childContext = new CompilationFileContext
                {
                    FilePath = context.FilePath,
                    NamespaceName = context.NamespaceName
                };

                return Instances.ContextOperator.In_Context(
                    childContext,
                    operations);
            };
        }

        public Func<TContext, Task> In_CompilationFileContext<TContext>(
            out (IsSet<IHasFilePath>, IsSet<IHasNamespaceName>) propertiesSet,
            params Func<CompilationFileContext, Task>[] operations)
            where TContext : IHasFilePath, IHasNamespaceName
        {
            return this.In_CompilationFileContext<TContext>(
                out propertiesSet,
                operations.AsEnumerable());
        }
    }
}
