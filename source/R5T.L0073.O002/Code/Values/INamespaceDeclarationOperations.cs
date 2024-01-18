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
        [Obsolete("Bad abstraction. See INamespaceDeclarationContextOperations.Add_Class()")]
        public Func<NamespaceDeclarationSyntax, TCompilationUnitContext, NamespaceDeclarationSyntax>
            Add_Class_Bad<TCompilationUnitContext, TNamespaceDeclarationContext>(
            string className,
            Func<NamespaceDeclarationSyntax, TCompilationUnitContext, TNamespaceDeclarationContext> namespaceDeclarationContextConstructor,
            IEnumerable<Func<ClassDeclarationSyntax, TNamespaceDeclarationContext, ClassDeclarationSyntax>> classModifiers)
            where TCompilationUnitContext : ICompilationUnitContext
            where TNamespaceDeclarationContext : INamespaceDeclarationContext
        {
            return (namespaceDeclaration, compilationUnitContext) =>
            {
                var namespaceDeclarationContext = namespaceDeclarationContextConstructor(
                    namespaceDeclaration,
                    compilationUnitContext);

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

        [Obsolete("Bad abstraction. See INamespaceDeclarationContextOperations.Add_Class()")]
        public Func<NamespaceDeclarationSyntax, ICompilationUnitContext, NamespaceDeclarationSyntax> Add_Class_Bad(
            string className,
            IEnumerable<Func<ClassDeclarationSyntax, INamespaceDeclarationContext, ClassDeclarationSyntax>> classModifiers)
        {
            return this.Add_Class_Bad<ICompilationUnitContext, INamespaceDeclarationContext>(
                className,
                Instances.NamespaceDeclarationContextConstructors.New_NamespaceDeclarationContext,
                classModifiers);

            //return (namespaceDeclaration, compilationUnitContext) =>
            //{
            //    var namespaceDeclarationContext = new NamespaceDeclarationContext
            //    {
            //        NamespaceDeclaration = namespaceDeclaration,
            //        CompilationUnit = compilationUnitContext.CompilationUnit,
            //    };

            //    var classDeclaration = Instances.SyntaxGenerator.Class(className);

            //    foreach (var classModifier in classModifiers)
            //    {
            //        classDeclaration = classModifier(
            //            classDeclaration,
            //            namespaceDeclarationContext);
            //    }

            //    // Set the possibly modified compilation unit.
            //    compilationUnitContext.CompilationUnit = namespaceDeclarationContext.CompilationUnit;

            //    var output = Instances.NamespaceDeclarationOperator.Add_Class(
            //        // Use the possibly modified namespace declaration.
            //        namespaceDeclarationContext.NamespaceDeclaration,
            //        classDeclaration);

            //    return output;
            //};
        }

        [Obsolete("Bad abstraction. See INamespaceDeclarationContextOperations.Add_Class()")]
        public Func<NamespaceDeclarationSyntax, ICompilationUnitContext, NamespaceDeclarationSyntax> Add_Class_Bad(
            string className,
            params Func<ClassDeclarationSyntax, INamespaceDeclarationContext, ClassDeclarationSyntax>[] classModifiers)
        {
            return this.Add_Class_Bad(
                className,
                classModifiers.AsEnumerable());
        }
    }
}
