using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0131;

using R5T.L0073.T001;
using R5T.L0073.T002;


namespace R5T.L0073
{
    [ValuesMarker]
    public partial interface ICompilationUnitOperations : IValuesMarker,
        F002.ICompilationUnitOperations,
        O002.ICompilationUnitOperations
    {
        public Action<TCompilationUnitContext> Add_Namespace<TCompilationUnitContext>(
            string namespaceName,
            IEnumerable<Action<INamespaceDeclarationContext>> namespaceDeclarationContextActions)
            where TCompilationUnitContext : IWithCompilationUnit
        {
            return this.Add_Namespace<TCompilationUnitContext, INamespaceDeclarationContext>(
                namespaceName,
                Instances.NamespaceDeclarationContextConstructors.New_NamespaceDeclarationContext,
                namespaceDeclarationContextActions);
        }

        public Action<TCompilationUnitContext> Add_Namespace<TCompilationUnitContext>(
            string namespaceName,
            params Action<INamespaceDeclarationContext>[] namespaceDeclarationContextActions)
            where TCompilationUnitContext : IWithCompilationUnit
        {
            return this.Add_Namespace<TCompilationUnitContext>(
                namespaceName,
                namespaceDeclarationContextActions.AsEnumerable());
        }
    }
}
