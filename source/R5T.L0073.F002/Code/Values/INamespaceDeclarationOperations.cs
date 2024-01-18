using System;
using System.Collections.Generic;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;

using R5T.L0073.T001;


namespace R5T.L0073.F002
{
    [ValuesMarker]
    public partial interface INamespaceDeclarationOperations : IValuesMarker
    {
        public Action<TNamespaceDeclarationContext> Add_Class<TNamespaceDeclarationContext, TClassDeclarationContext>(
            string className,
            Func<ClassDeclarationSyntax, TNamespaceDeclarationContext, TClassDeclarationContext> classDeclarationContextConstructor,
            IEnumerable<Action<TClassDeclarationContext>> classDeclarationContextActions)
            where TNamespaceDeclarationContext : IWithNamespaceDeclaration
            where TClassDeclarationContext : IHasClassDeclaration
        {
            return namespaceDeclarationContext =>
            {
                var classDeclaration = Instances.SyntaxGenerator.Class(className);

                var classDeclarationContext = classDeclarationContextConstructor(
                    classDeclaration,
                    namespaceDeclarationContext);

                Instances.ContextOperator.In_Context(
                    classDeclarationContext,
                    classDeclarationContextActions);

                Instances.NamespaceDeclarationOperator.Add_Class(
                    namespaceDeclarationContext,
                    classDeclarationContext.ClassDeclaration);
            };
        }
    }
}
