using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.L0073.F001
{
    [ValuesMarker]
    public partial interface IMemberDeclarationOperations : IValuesMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Raw.IMemberDeclarationOperations _Raw => Raw.MemberDeclarationOperations.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public Func<TMemberDeclarationSyntax, TMemberDeclarationSyntax> In_ModifyModifiersContext<TMemberDeclarationSyntax>(
            IEnumerable<Func<SyntaxTokenList, SyntaxTokenList>> modifiersModifiers)
            where TMemberDeclarationSyntax : MemberDeclarationSyntax
        {
            return memberDeclaration => Instances.MemberDeclarationOperator.In_ModifyModifiersContext(
                memberDeclaration,
                modifiersModifiers);
        }

        public Func<TMemberDeclarationSyntax, TMemberDeclarationSyntax> In_ModifyModifiersContext<TMemberDeclarationSyntax>(
            params Func<SyntaxTokenList, SyntaxTokenList>[] modifiersModifiers)
            where TMemberDeclarationSyntax : MemberDeclarationSyntax
        {
            return this.In_ModifyModifiersContext<TMemberDeclarationSyntax>(modifiersModifiers.AsEnumerable());
        }

        public Func<TMemberDeclarationSyntax, TMemberDeclarationSyntax> In_ModifyModifiersContext<TMemberDeclarationSyntax>(
            IEnumerable<Func<TMemberDeclarationSyntax, TMemberDeclarationSyntax>> modifiersModifiers)
            where TMemberDeclarationSyntax : MemberDeclarationSyntax
        {
            return memberDeclaration => Instances.MemberDeclarationOperator.In_ModifyModifiersContext(
                memberDeclaration,
                modifiersModifiers);
        }

        public Func<TMemberDeclarationSyntax, TMemberDeclarationSyntax> In_ModifyModifiersContext<TMemberDeclarationSyntax>(
            params Func<TMemberDeclarationSyntax, TMemberDeclarationSyntax>[] modifiersModifiers)
            where TMemberDeclarationSyntax : MemberDeclarationSyntax
        {
            return this.In_ModifyModifiersContext<TMemberDeclarationSyntax>(modifiersModifiers.AsEnumerable());
        }
    }
}
