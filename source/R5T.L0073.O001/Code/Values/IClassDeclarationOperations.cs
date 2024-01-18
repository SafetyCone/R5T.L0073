using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;

using R5T.L0073.T001;


namespace R5T.L0073.O001
{
    [ValuesMarker]
    public partial interface IClassDeclarationOperations : IValuesMarker
    {
        public void Add_Main_Asynchronous<TClassDeclarationContext>(TClassDeclarationContext classDeclarationContext)
            where TClassDeclarationContext : IWithClassDeclaration, IWithCompilationUnit
        {
            // Add the asynchronous main method.
            Instances.ClassDeclarationOperator.Add_Method(
                classDeclarationContext,
                Instances.MethodDeclarations.Main_Asynchronous);

            // Add the System.Threading.Tasks using directive.
            Instances.CompilationUnitOperator.Add_UsingDirective(
                classDeclarationContext,
                Instances.UsingDirectives.System_Threading_Tasks);
        }

        public ClassDeclarationSyntax Add_Main_Asynchonous<TContext>(
            ClassDeclarationSyntax classDeclaration,
            TContext context)
            where TContext : IWithCompilationUnit
        {
            // Add the asynchronous main method.
            var output = Instances.ClassDeclarationOperator.Add_Method(
                classDeclaration,
                Instances.MethodDeclarations.Main_Asynchronous);

            // Add the System.Threading.Tasks using directive.
            context.CompilationUnit = Instances.CompilationUnitOperator.Add_UsingDirective(
                context.CompilationUnit,
                Instances.UsingDirectives.System_Threading_Tasks);

            return output;
        }
    }
}
