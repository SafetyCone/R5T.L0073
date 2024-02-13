using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.L0073.T001;
using R5T.T0221;
using R5T.T0241;


namespace R5T.L0073.O003
{
    [ContextOperationsMarker]
    public partial interface IMethodDeclarationContextOperations : IContextOperationsMarker
    {
        public Task Add_MethodDeclaration_ToClassDeclaration<TContext>(TContext context)
            where TContext : IWithClassDeclaration, IHasMethodDeclaration
        {
            return Instances.ClassDeclarationContextOperations.Add_MethodDeclaration_ToClassDeclaration(context);
        }

        public Task Add_Statement_ToMethodDeclaration<TContext>(TContext context)
            where TContext : IWithMethodDeclaration, IHasStatement
        {
            context.MethodDeclaration = Instances.MethodDeclarationOperator.Add_Statement(
                context.MethodDeclaration,
                context.Statement);

            return Task.CompletedTask;
        }

        public Func<TContext, Task> In_StatementDeclarationContext<TContext, TStatementContext>(
            out (IsSet<IHasCompilationUnit>, IsSet<IHasNamespaceDeclaration>, IsSet<IHasMethodDeclaration>) propertiesSet,
            IEnumerable<Func<TStatementContext, Task>> operations)
            where TContext : IWithCompilationUnit, IWithNamespaceDeclaration, IWithMethodDeclaration
            where TStatementContext : IWithCompilationUnit, IWithNamespaceDeclaration, IWithMethodDeclaration, new()
        {
            return async context =>
            {
                var childContext = new TStatementContext
                {
                    CompilationUnit = context.CompilationUnit,
                    NamespaceDeclaration = context.NamespaceDeclaration,
                    //ClassDeclaration = context.ClassDeclaration,
                    MethodDeclaration = context.MethodDeclaration,
                };

                await Instances.ContextOperator.In_Context(
                    childContext,
                    operations);

                context.MethodDeclaration = childContext.MethodDeclaration;
                context.NamespaceDeclaration = childContext.NamespaceDeclaration;
                context.CompilationUnit = childContext.CompilationUnit;
            };
        }

        public Func<TContext, Task> In_StatementDeclarationContext<TContext, TStatementContext>(
            out (IsSet<IHasCompilationUnit>, IsSet<IHasNamespaceDeclaration>, IsSet<IHasMethodDeclaration>) propertiesSet,
            params Func<TStatementContext, Task>[] operations)
            where TContext : IWithCompilationUnit, IWithNamespaceDeclaration, IWithMethodDeclaration
            where TStatementContext : IWithCompilationUnit, IWithNamespaceDeclaration, IWithMethodDeclaration, new()
        {
            return this.In_StatementDeclarationContext<TContext, TStatementContext>(
                out propertiesSet,
                operations.AsEnumerable());
        }

        public Func<TContext, Task> Modify_Modifiers<TContext>(
            IsSet<IHasMethodDeclaration> classDeclarationSet,
            Func<SyntaxTokenList, SyntaxTokenList> modifersModifier)
            where TContext : IWithMethodDeclaration, IWithMemberDeclarationType<MethodDeclarationSyntax>
        {
            return Instances.MemberDeclarationContextOperations.Modify_Modifiers<TContext, MethodDeclarationSyntax>(
                new IsSet<IHasMemberDeclaration>(),
                modifersModifier);
        }

        public Func<TContext, Task> Set_MethodDeclaration_New<TContext>(
            string methodName,
            TypeSyntax returnType,
            out IsSet<IHasMethodDeclaration> methodDeclarationSet)
            where TContext : IWithMethodDeclaration
        {
            return context =>
            {
                context.MethodDeclaration = Instances.SyntaxGenerator.MethodDeclaration(
                    returnType,
                    methodName);

                return Task.CompletedTask;
            };
        }
    }
}
