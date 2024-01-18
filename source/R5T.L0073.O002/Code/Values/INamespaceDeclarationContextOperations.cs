using System;
using System.Collections.Generic;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;

using R5T.L0073.T001;


namespace R5T.L0073.O002
{
    [ValuesMarker]
    public partial interface INamespaceDeclarationContextOperations : IValuesMarker
    {
        public Action<TNamespaceDeclarationContext> Add_Class<TNamespaceDeclarationContext, TClassDeclarationContext>(
            string className,
            Func<ClassDeclarationSyntax, TNamespaceDeclarationContext, TClassDeclarationContext> classDeclarationContextConstructor,
            IEnumerable<Action<TClassDeclarationContext>> classModifiers)
            where TNamespaceDeclarationContext : IWithNamespaceDeclaration
        {
            return namespaceDeclarationContext =>
            {
                var classDeclaration = Instances.SyntaxGenerator.Class(className);

                var classDeclarationContext = classDeclarationContextConstructor(
                    classDeclaration,
                    namespaceDeclarationContext);

                foreach (var classModifier in classModifiers)
                {
                    classModifier(classDeclarationContext);
                }

                namespaceDeclarationContext.NamespaceDeclaration = Instances.NamespaceDeclarationOperator.Add_Class(
                    // Use the possibly modified namespace declaration.
                    namespaceDeclarationContext.NamespaceDeclaration,
                    classDeclaration);
            };
        }
    }
}
