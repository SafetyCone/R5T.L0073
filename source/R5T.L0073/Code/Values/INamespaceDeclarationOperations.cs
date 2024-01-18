using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0131;

using R5T.L0073.T001;
using R5T.L0073.T002;


namespace R5T.L0073
{
    [ValuesMarker]
    public partial interface INamespaceDeclarationOperations : IValuesMarker,
        F002.INamespaceDeclarationOperations,
        O002.INamespaceDeclarationOperations
    {
        public Action<TNamespaceDeclarationContext> Add_Class<TNamespaceDeclarationContext>(
            string className,
            IEnumerable<Action<IClassDeclarationContext>> classDeclarationContextActions)
            where TNamespaceDeclarationContext :
                IWithCompilationUnit,    
                IWithNamespaceDeclaration
        {
            return this.Add_Class<TNamespaceDeclarationContext, IClassDeclarationContext>(
                className,
                Instances.ClassDeclarationContextConstructors.New_ClassDeclarationContext,
                classDeclarationContextActions);
        }

        public Action<TNamespaceDeclarationContext> Add_Class<TNamespaceDeclarationContext>(
            string className,
            params Action<IClassDeclarationContext>[] classDeclarationContextActions)
            where TNamespaceDeclarationContext :
                IWithCompilationUnit,
                IWithNamespaceDeclaration
        {
            return this.Add_Class<TNamespaceDeclarationContext>(
                className,
                classDeclarationContextActions.AsEnumerable());
        }
    }
}
