using System;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.L0073.T001;
using R5T.T0221;
using R5T.T0241;


namespace R5T.L0073.O003
{
    [ContextOperationsMarker]
    public partial interface IMemberDeclarationContextOperations : IContextOperationsMarker
    {
        public Func<TContext, Task> Modify_Modifiers<TContext, TMemberDeclaration>(
            IsSet<IHasMemberDeclaration> memberDeclarationSet,
            Func<SyntaxTokenList, SyntaxTokenList> modifersModifier)
            where TContext : IWithMemberDeclarationType<TMemberDeclaration>
            where TMemberDeclaration : MemberDeclarationSyntax
        {
            return context =>
            {
                var modifiedModifiers = modifersModifier(context.MemberDeclaration.Modifiers);

                context.MemberDeclaration = context.MemberDeclaration.WithModifiers(modifiedModifiers) as TMemberDeclaration;

                if (modifiedModifiers.Any())
                {
                    // Now set trailing separating spacing for the last modifier.
                    var newModifiedModifiers = context.MemberDeclaration.Modifiers;

                    var lastModifier = Instances.SyntaxTokenListOperator.Get_Last(newModifiedModifiers);

                    context.MemberDeclaration = Instances.SyntaxTokenOperator.Set_TrailingSeparatingSpacing(
                        lastModifier,
                        Instances.SyntaxTriviaLists.Space,
                        context.MemberDeclaration);
                }

                return Task.CompletedTask;
            };
        }
    }
}
