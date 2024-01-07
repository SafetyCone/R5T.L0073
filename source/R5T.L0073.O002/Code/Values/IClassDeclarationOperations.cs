using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;

using R5T.L0073.T002;


namespace R5T.L0073.O002
{
    [ValuesMarker]
    public partial interface IClassDeclarationOperations : IValuesMarker
    {
        public Func<ClassDeclarationSyntax, INamespaceDeclarationContext, ClassDeclarationSyntax> Add_Method(
            TypeSyntax returnType,
            string simpleMethodName,
            IEnumerable<Func<MethodDeclarationSyntax, IClassDeclarationContext, MethodDeclarationSyntax>> methodModifiers)
        {
            return (classDeclaration, namespaceDeclarationContext) =>
            {
                var classDeclarationContext = new ClassDeclarationContext
                {
                    ClassDeclaration = classDeclaration,
                    NamespaceDeclaration = namespaceDeclarationContext.NamespaceDeclaration,
                    CompilationUnit = namespaceDeclarationContext.CompilationUnit,
                };

                var method = Instances.SyntaxGenerator.MethodDeclaration(
                    returnType,
                    simpleMethodName);

                foreach (var methodModifier in methodModifiers)
                {
                    method = methodModifier(
                        method,
                        classDeclarationContext);
                }

                // Set the possibly modified context values.
                namespaceDeclarationContext.NamespaceDeclaration = classDeclarationContext.NamespaceDeclaration;
                namespaceDeclarationContext.CompilationUnit = classDeclarationContext.CompilationUnit;

                var output = Instances.ClassDeclarationOperator.Add_Method(
                    // Use the possibly modified class declaration.
                    classDeclarationContext.ClassDeclaration,
                    method);

                return output;
            };
        }

        public Func<ClassDeclarationSyntax, INamespaceDeclarationContext, ClassDeclarationSyntax> Add_Method(
            TypeSyntax returnType,
            string simpleMethodName,
            params Func<MethodDeclarationSyntax, IClassDeclarationContext, MethodDeclarationSyntax>[] methodModifiers)
        {
            return this.Add_Method(
                returnType,
                simpleMethodName,
                methodModifiers.AsEnumerable());
        }
    }
}
