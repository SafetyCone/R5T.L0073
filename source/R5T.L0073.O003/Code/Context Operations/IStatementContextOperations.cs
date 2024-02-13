using System;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.L0073.T001;
using R5T.T0221;
using R5T.T0241;


namespace R5T.L0073.O003
{
    [ContextOperationsMarker]
    public partial interface IStatementContextOperations : IContextOperationsMarker
    {
        public Task Add_Statement_ToMethodDeclaration<TContext>(TContext context)
            where TContext : IWithMethodDeclaration, IHasStatement
        {
            return Instances.MethodDeclarationContextOperations.Add_Statement_ToMethodDeclaration(context);
        }

        public Func<TContext, Task> Set_Statement<TContext>(
            StatementSyntax statement,
            out IsSet<IHasStatement> statementSet)
            where TContext : IWithStatement
        {
            return context =>
            {
                context.Statement = statement;

                return Task.CompletedTask;
            };
        }
    }
}
