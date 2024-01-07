using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.L0073.F001
{
    [FunctionalityMarker]
    public partial interface IMemberDeclarationOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Raw.IMemberDeclarationOperator _Raw => Raw.MemberDeclarationOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public TMemberDeclarationSyntax Add_Modifiers<TMemberDeclarationSyntax>(
            TMemberDeclarationSyntax memberDeclaration,
            IEnumerable<SyntaxToken> modifiers)
            where TMemberDeclarationSyntax : MemberDeclarationSyntax
        {
            var modifiersArray = modifiers.ToArray();

            var output = this.Add_Modifiers(
                memberDeclaration,
                modifiersArray);

            return output;
        }

        public TMemberDeclarationSyntax Add_Modifiers<TMemberDeclarationSyntax>(
            TMemberDeclarationSyntax memberDeclaration,
            params SyntaxToken[] modifiers)
            where TMemberDeclarationSyntax : MemberDeclarationSyntax
        {
            var output = memberDeclaration.AddModifiers(modifiers) as TMemberDeclarationSyntax;
            return output;
        }

        public TMemberDeclarationSyntax Add_Modifier<TMemberDeclarationSyntax>(
            TMemberDeclarationSyntax memberDeclaration,
            SyntaxToken modifier)
            where TMemberDeclarationSyntax : MemberDeclarationSyntax
        {
            var output = this.Add_Modifiers(
                memberDeclaration,
                modifier);

            return output;
        }

        public SyntaxTokenList Get_Modifiers(MemberDeclarationSyntax memberDeclaration)
        {
            var output = memberDeclaration.Modifiers;
            return output;
        }

        public TMemberDeclarationSyntax Add_PrivateModifier<TMemberDeclarationSyntax>(TMemberDeclarationSyntax memberDeclaration)
            where TMemberDeclarationSyntax : MemberDeclarationSyntax
        {
            var privateKeyword = Instances.SyntaxTokens.Private_Keyword;

            return this.Add_Modifier(
                memberDeclaration,
                privateKeyword);
        }

        public TMemberDeclarationSyntax Add_PublicModifier<TMemberDeclarationSyntax>(TMemberDeclarationSyntax memberDeclaration)
            where TMemberDeclarationSyntax : MemberDeclarationSyntax
        {
            var publicKeyword = Instances.SyntaxTokens.Public_Keyword;

            return this.Add_Modifier(
                memberDeclaration,
                publicKeyword);
        }

        public TMemberDeclarationSyntax Add_StaticModifier<TMemberDeclarationSyntax>(TMemberDeclarationSyntax memberDeclaration)
            where TMemberDeclarationSyntax : MemberDeclarationSyntax
        {
            var publicKeyword = Instances.SyntaxTokens.Static_Keyword;

            return this.Add_Modifier(
                memberDeclaration,
                publicKeyword);
        }

        /// <summary>
        /// Over and above <see cref="Raw.IMemberDeclarationOperator.In_ModifyModifiersContext{TMemberDeclarationSyntax}(TMemberDeclarationSyntax, IEnumerable{Func{SyntaxTokenList, SyntaxTokenList}})"/>,
        /// after performing the input modifier actions this method:
        /// <list type="number">
        /// <item>Spaces modifiers</item>
        /// <item>Re-orders modifiers to be in an order valid for compilation.</item>
        /// <item>Sets the trailing separating space between the last modifier and the first member token.</item>
        /// </list>
        /// </summary>
        public TMemberDeclarationSyntax In_ModifyModifiersContext<TMemberDeclarationSyntax>(
            TMemberDeclarationSyntax memberDeclaration,
            IEnumerable<Func<SyntaxTokenList, SyntaxTokenList>> modifiersModifiers)
            where TMemberDeclarationSyntax : MemberDeclarationSyntax
        {
            // What a name, hehe!
            var modifiedModifiersModifiers = modifiersModifiers.Append(
                    Instances.ModifiersOperator.Ensure_OrderIsValid,
                    Instances.ModifiersOperator.Ensure_SeparatingSpacing
                );

            var modifiedMemberDeclaration = _Raw.In_ModifyModifiersContext(
                memberDeclaration,
                modifiedModifiersModifiers);

            // Now set the trailing separating space of the last modifier.
            var modifiers = this.Get_Modifiers(modifiedMemberDeclaration);

            var lastModifier = Instances.SyntaxTokenListOperator.Get_Last(modifiers);

            var output = Instances.SyntaxTokenOperator.Set_TrailingSeparatingSpacing(
                lastModifier,
                Instances.SyntaxTriviaLists.Space,
                modifiedMemberDeclaration);

            return output;
        }

        public TMemberDeclarationSyntax In_ModifyModifiersContext<TMemberDeclarationSyntax>(
            TMemberDeclarationSyntax memberDeclaration,
            IEnumerable<Func<TMemberDeclarationSyntax, TMemberDeclarationSyntax>> modifiersModifiers)
            where TMemberDeclarationSyntax : MemberDeclarationSyntax
        {
            // Run the member-declaration level actions.
            var modifiedMemberDeclaration = Instances.SyntaxOperator.Modify(
                memberDeclaration,
                modifiersModifiers);

            // Now call the syntax toke list-level method to do the actual modifiers spacing.
            var output = this.In_ModifyModifiersContext(
                modifiedMemberDeclaration,
                Instances.EnumerableOperator.Empty<Func<SyntaxTokenList, SyntaxTokenList>>());

            return output;
        }
    }
}
