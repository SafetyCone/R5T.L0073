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
    public partial interface IClassDeclarationContextOperations : IContextOperationsMarker
    {
        public Task Add_ClassDeclaration_ToNamespaceDeclaration<TContext>(TContext context)
            where TContext : IWithNamespaceDeclaration, IHasClassDeclaration
        {
            return Instances.NamespaceDeclarationContextOperations.Add_ClassDeclaration_ToNamespaceDeclaration(context);
        }

        public Task Add_MethodDeclaration_ToClassDeclaration<TContext>(TContext context)
            where TContext : IWithClassDeclaration, IHasMethodDeclaration
        {
            context.ClassDeclaration = Instances.ClassDeclarationOperator.Add_Method(
                context.ClassDeclaration,
                context.MethodDeclaration);

            return Task.CompletedTask;
        }

        public Func<TContext, Task> In_MethodDeclarationContext<TContext, TMethodDeclarationContext>(
            out (IsSet<IHasCompilationUnit>, IsSet<IHasNamespaceDeclaration>, IsSet<IHasClassDeclaration>, IsSet<IHasMemberDeclaration>) propertiesSet,
            IEnumerable<Func<TMethodDeclarationContext, Task>> operations)
            where TContext : IWithCompilationUnit, IWithNamespaceDeclaration, IWithClassDeclaration
            where TMethodDeclarationContext : IWithCompilationUnit, IWithNamespaceDeclaration, IWithClassDeclaration, new()
        {
            return async context =>
            {
                var childContext = new TMethodDeclarationContext
                {
                    CompilationUnit = context.CompilationUnit,
                    NamespaceDeclaration = context.NamespaceDeclaration,
                    ClassDeclaration = context.ClassDeclaration,
                };

                await Instances.ContextOperator.In_Context(
                    childContext,
                    operations);

                context.ClassDeclaration = childContext.ClassDeclaration;
                context.NamespaceDeclaration = childContext.NamespaceDeclaration;
                context.CompilationUnit = childContext.CompilationUnit;
            };
        }

        public Func<TContext, Task> In_MethodDeclarationContext<TContext, TMethodDeclarationContext>(
            out (IsSet<IHasCompilationUnit>, IsSet<IHasNamespaceDeclaration>, IsSet<IHasClassDeclaration>, IsSet<IHasMemberDeclaration>) propertiesSet,
            params Func<TMethodDeclarationContext, Task>[] operations)
            where TContext : IWithCompilationUnit, IWithNamespaceDeclaration, IWithClassDeclaration
            where TMethodDeclarationContext : IWithCompilationUnit, IWithNamespaceDeclaration, IWithClassDeclaration, new()
        {
            return this.In_MethodDeclarationContext<TContext, TMethodDeclarationContext>(
                out propertiesSet,
                operations.AsEnumerable());
        }

        public Func<TContext, Task> Modify_Modifiers<TContext>(
            IsSet<IHasClassDeclaration> classDeclarationSet,
            Func<SyntaxTokenList, SyntaxTokenList> modifersModifier)
            where TContext : IWithClassDeclaration, IWithMemberDeclarationType<ClassDeclarationSyntax>
        {
            return Instances.MemberDeclarationContextOperations.Modify_Modifiers<TContext, ClassDeclarationSyntax>(
                new IsSet<IHasMemberDeclaration>(),
                modifersModifier);
        }

        public Func<TContext, Task> Set_ClassDeclaration_New<TContext>(
            string className,
            out IsSet<IHasClassDeclaration> classDeclarationSet)
            where TContext : IWithClassDeclaration
        {
            return context =>
            {
                context.ClassDeclaration = Instances.SyntaxGenerator.Class(className);

                return Task.CompletedTask;
            };
        }
    }
}
