using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;

using R5T.L0073.T002;


namespace R5T.L0073.O002
{
    [ValuesMarker]
    public partial interface INamespaceDeclarationOperations : IValuesMarker
    {
        public Func<NamespaceDeclarationSyntax, ICompilationUnitContext, NamespaceDeclarationSyntax> Add_Class(
            string className,
            IEnumerable<Func<ClassDeclarationSyntax, INamespaceDeclarationContext, ClassDeclarationSyntax>> classModifiers)
        {
            return (namespaceDeclaration, compilationUnitContext) =>
            {
                var namespaceDeclarationContext = new NamespaceDeclarationContext
                {
                    NamespaceDeclaration = namespaceDeclaration,
                    CompilationUnit = compilationUnitContext.CompilationUnit,
                };

                var classDeclaration = Instances.SyntaxGenerator.Class(className);

                foreach (var classModifier in classModifiers)
                {
                    classDeclaration = classModifier(
                        classDeclaration,
                        namespaceDeclarationContext);
                }

                // Set the possibly modified compilation unit.
                compilationUnitContext.CompilationUnit = namespaceDeclarationContext.CompilationUnit;

                var output = Instances.NamespaceDeclarationOperator.Add_Class(
                    // Use the possibly modified namespace declaration.
                    namespaceDeclarationContext.NamespaceDeclaration,
                    classDeclaration);

                return output;
            };
        }

        public Func<NamespaceDeclarationSyntax, ICompilationUnitContext, NamespaceDeclarationSyntax> Add_Class(
            string className,
            params Func<ClassDeclarationSyntax, INamespaceDeclarationContext, ClassDeclarationSyntax>[] classModifiers)
        {
            return this.Add_Class(
                className,
                classModifiers.AsEnumerable());
        }
    }
}
