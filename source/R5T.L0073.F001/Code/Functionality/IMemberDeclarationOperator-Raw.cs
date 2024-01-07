using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.L0073.F001.Raw
{
    [FunctionalityMarker]
    public partial interface IMemberDeclarationOperator : IFunctionalityMarker
    {
        public TMemberDeclarationSyntax In_ModifyModifiersContext<TMemberDeclarationSyntax>(
            TMemberDeclarationSyntax memberDeclaration,
            IEnumerable<Func<SyntaxTokenList, SyntaxTokenList>> modifiersModifiers)
            where TMemberDeclarationSyntax : MemberDeclarationSyntax
        {
            var modifiers = Instances.MemberDeclarationOperator.Get_Modifiers(memberDeclaration);

            var newModifiers = Instances.FunctionOperator.Run_Modifiers(
                modifiers,
                modifiersModifiers);

            // Cannot use ReplaceToken() ReplaceNode() since a syntax token list is not a token or a node!
            var newMemberDeclaration = memberDeclaration.WithModifiers(newModifiers) as TMemberDeclarationSyntax;
            return newMemberDeclaration;
        }

        public TMemberDeclarationSyntax In_ModifyModifiersContext<TMemberDeclarationSyntax>(
            TMemberDeclarationSyntax memberDeclaration,
            params Func<SyntaxTokenList, SyntaxTokenList>[] modifiersModifiers)
            where TMemberDeclarationSyntax : MemberDeclarationSyntax
        {
            return this.In_ModifyModifiersContext(
                memberDeclaration,
                modifiersModifiers.AsEnumerable());
        }
    }
}
