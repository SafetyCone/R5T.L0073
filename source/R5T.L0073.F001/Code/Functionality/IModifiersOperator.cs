using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using R5T.T0132;


namespace R5T.L0073.F001
{
    [FunctionalityMarker]
    public partial interface IModifiersOperator : IFunctionalityMarker
    {
        public SyntaxTokenList Add_Async(SyntaxTokenList tokens)
        {
            var output = tokens.Add(Instances.SyntaxTokens.Async_Keyword);
            return output;
        }

        public SyntaxTokenList Add_Private(SyntaxTokenList tokens)
        {
            var output = tokens.Add(Instances.SyntaxTokens.Private_Keyword);
            return output;
        }

        public SyntaxTokenList Add_Public(SyntaxTokenList tokens)
        {
            var output = tokens.Add(Instances.SyntaxTokens.Public_Keyword);
            return output;
        }

        public SyntaxTokenList Add_Static(SyntaxTokenList tokens)
        {
            var output = tokens.Add(Instances.SyntaxTokens.Static_Keyword);
            return output;
        }

        /// <summary>
        /// Given a set of member modifiers (public, static, partial, etc.), ensure they are ordered in a valid way.
        /// </summary>
        /// <remarks>
        /// The order is given by <inheritdoc cref="Y000.Links.ForAccessModifiersOrder" path="/descendant::value"/>.
        /// </remarks>
        public SyntaxTokenList Ensure_OrderIsValid(SyntaxTokenList modifers)
        {
            var modifiersDescriptor = this.Get_Descriptor(modifers);

            var output = this.Get_ModifiersTokenList_InOrder(modifiersDescriptor);
            return output;
        }

        public SyntaxTokenList Ensure_SeparatingSpacing(SyntaxTokenList modifiers)
        {
            var firstIndex = 0;
            var lastIndex = modifiers.Count - 1;
            var index = 0;

            var tokens = modifiers
                .Select(token =>
                {
                    // Don't remove leading trivia from the first modifier (since it could be the line spacing for the member).
                    if (index != firstIndex)
                    {
                        // Add a leading separating space.
                        token = token.WithLeadingTrivia(Instances.SyntaxTrivias.Whitespace_Space);
                    }

                    // Don't remove trailing trivia from the last modifier (it shouldn't matter, but this method advertises itself as "separating" spacing).
                    if (index != lastIndex)
                    {
                        // Remove trailing trivia.
                        token = token.WithTrailingTrivia();
                    }

                    index++;

                    return token;
                });

            var output = Instances.SyntaxGenerator.SyntaxTokenList(tokens);
            return output;
        }

        public SyntaxTokenList Get_ModifiersTokenList_InOrder(ModifiersDescriptor descriptor)
        {
            var modifiers = Instances.EnumerableOperator.New<SyntaxToken>();

            var modifierValues = Instances.MemberModifiers;

            modifiers = descriptor.Accessibility switch
            {
                MemberAccessibilityLevel.File => modifiers.Append(modifierValues.File),
                MemberAccessibilityLevel.Internal => modifiers.Append(modifierValues.Internal),
                MemberAccessibilityLevel.Private => modifiers.Append(modifierValues.Private),
                MemberAccessibilityLevel.PrivateProtected => modifiers.Append(
                    modifierValues.Private,
                    modifierValues.Protected),
                MemberAccessibilityLevel.Protected => modifiers.Append(modifierValues.Protected),
                MemberAccessibilityLevel.ProtectedInternal => modifiers.Append(
                    modifierValues.Protected,
                    modifierValues.Internal),
                MemberAccessibilityLevel.Public => modifiers.Append(modifierValues.Public),
                // If unspecified, do nothing.
                MemberAccessibilityLevel.Unspecified => modifiers,
                // Choose correct over robust, and throw an exception.
                _ => throw Instances.SwitchOperator.Get_UnexpectedEnumerationValueException(descriptor.Accessibility),
            };

            modifiers = descriptor.Is_Static
                ? modifiers.Append(modifierValues.Static)
                : modifiers
                ;

            modifiers = descriptor.Is_Extern
                ? modifiers.Append(modifierValues.Extern)
                : modifiers
                ;

            modifiers = descriptor.Is_New
                ? modifiers.Append(modifierValues.New)
                : modifiers
                ;

            modifiers = descriptor.Implementation switch
            {
                ImplementationLevel.Abstract => modifiers.Append(modifierValues.Abstract),
                ImplementationLevel.Override => modifiers.Append(modifierValues.Override),
                ImplementationLevel.Virtual => modifiers.Append(modifierValues.Virtual),
                // If unspecified, do nothing.
                ImplementationLevel.Unspecified => modifiers,
                // Choose correct over robust, and throw an exception.
                _ => throw Instances.SwitchOperator.Get_UnexpectedEnumerationValueException(descriptor.Implementation),
            };

            // Technically, it's possible to have a sealed override. TODO: fix.
            modifiers = descriptor.Is_Sealed
                ? modifiers.Append(modifierValues.Sealed)
                : modifiers
                ;

            modifiers = descriptor.Is_ReadOnly
                ? modifiers.Append(modifierValues.Readonly)
                : modifiers
                ;

            modifiers = descriptor.Is_Unsafe
                ? modifiers.Append(modifierValues.Unsafe)
                : modifiers
                ;

            modifiers = descriptor.Is_Required
                ? modifiers.Append(modifierValues.Required)
                : modifiers
                ;

            modifiers = descriptor.Is_Volatile
                ? modifiers.Append(modifierValues.Volatile)
                : modifiers
                ;

            modifiers = descriptor.Is_Async
                ? modifiers.Append(modifierValues.Async)
                : modifiers
                ;

            // Partial must be last.
            modifiers = descriptor.Is_Partial
                ? modifiers.Append(modifierValues.Partial)
                : modifiers
                ;

            var output = Instances.SyntaxGenerator.SyntaxTokenList(modifiers);
            return output;
        }

        /// <summary>
        /// Will throw an exception if there are any unhandled modifiers (from <see cref="Get_Descriptor(SyntaxTokenList, out SyntaxKind[])"/>).
        /// </summary>
        public ModifiersDescriptor Get_Descriptor(SyntaxTokenList modifiers)
        {
            var output = this.Get_Descriptor(
                modifiers,
                out var unhandledModifiers);

            if(unhandledModifiers.Any())
            {
                var unhandledModifiersList = Instances.TextOperator.Join_AsList(unhandledModifiers);

                throw new Exception($"Unhandled modifiers detected:\n\t{unhandledModifiersList}");
            }

            return output;
        }

        /// <summary>
        /// Robustly allow for unhandled modifiers.
        /// </summary>
        public ModifiersDescriptor Get_Descriptor(
            SyntaxTokenList modifiers,
            out SyntaxKind[] unhandledModifiers)
        {
            // Some combinations of accessibility modifiers are possible (but public and file are not).
            var hasPrivate = false;
            var hasProtected = false;
            var hasInternal = false;

            // Make dictionary values non-capturing of the modifiers descriptor (static).
            var modifiersDescriptorActionsByKeywordKind = new Dictionary<SyntaxKind, Action<ModifiersDescriptor>>
            {
                { SyntaxKind.AbstractKeyword, descriptor => descriptor.Implementation = ImplementationLevel.Abstract },
                { SyntaxKind.VirtualKeyword, descriptor => descriptor.Implementation = ImplementationLevel.Virtual },
                { SyntaxKind.OverrideKeyword, descriptor => descriptor.Implementation = ImplementationLevel.Override },
                { SyntaxKind.FileKeyword, descriptor => descriptor.Accessibility = MemberAccessibilityLevel.File },
                { SyntaxKind.PrivateKeyword, _ => hasPrivate = true },
                { SyntaxKind.ProtectedKeyword, _ => hasProtected = true },
                { SyntaxKind.InternalKeyword, _ => hasInternal = true },
                { SyntaxKind.PublicKeyword, descriptor => descriptor.Accessibility = MemberAccessibilityLevel.Public },
                { SyntaxKind.AsyncKeyword, descriptor => descriptor.Is_Async = true },
                { SyntaxKind.ConstKeyword, descriptor => descriptor.Is_Const = true },
                { SyntaxKind.ExternKeyword, descriptor => descriptor.Is_Extern = true },
                { SyntaxKind.NewKeyword, descriptor => descriptor.Is_New = true },
                { SyntaxKind.PartialKeyword, descriptor => descriptor.Is_Partial = true },
                { SyntaxKind.ReadOnlyKeyword, descriptor => descriptor.Is_ReadOnly = true },
                { SyntaxKind.RequiredKeyword, descriptor => descriptor.Is_Required = true },
                { SyntaxKind.SealedKeyword, descriptor => descriptor.Is_Sealed = true },
                { SyntaxKind.StaticKeyword, descriptor => descriptor.Is_Static = true },
                { SyntaxKind.UnsafeKeyword, descriptor => descriptor.Is_Unsafe = true },
                { SyntaxKind.VolatileKeyword, descriptor => descriptor.Is_Volatile = true },
            };

            var modifiersDescriptor = new ModifiersDescriptor();

            var unhandledModifiersList = new List<SyntaxKind>();

            foreach (var modifierToken in modifiers)
            {
                var modifierKind = Instances.SyntaxTokenOperator.Get_Kind(modifierToken);

                if(!modifiersDescriptorActionsByKeywordKind.ContainsKey(modifierKind))
                {
                    unhandledModifiersList.Add(modifierKind);

                    continue;
                }
                // Else

                var modifiersDescriptorAction = modifiersDescriptorActionsByKeywordKind[modifierKind];

                modifiersDescriptorAction(modifiersDescriptor);
            }

            unhandledModifiers = unhandledModifiersList.ToArray();

            if (hasPrivate || hasInternal || hasProtected)
            {
                // Handle possibility of multiple access modifiers.
                if (hasPrivate)
                {
                    if (hasProtected)
                    {
                        modifiersDescriptor.Accessibility = MemberAccessibilityLevel.PrivateProtected;
                    }
                    else
                    {
                        modifiersDescriptor.Accessibility = MemberAccessibilityLevel.Private;
                    }
                }
                else
                {
                    // Could be protected, protected internal, or internal.
                    if (hasProtected)
                    {
                        if (hasInternal)
                        {
                            modifiersDescriptor.Accessibility = MemberAccessibilityLevel.ProtectedInternal;
                        }
                        else
                        {
                            modifiersDescriptor.Accessibility = MemberAccessibilityLevel.Protected;
                        }
                    }
                    else
                    {
                        modifiersDescriptor.Accessibility = MemberAccessibilityLevel.Internal;
                    }
                }
            }

            return modifiersDescriptor;
        }

        public bool Is_Kind(
            SyntaxToken modifier,
            SyntaxKind kind)
        {
            var output = Instances.SyntaxTokenOperator.Is_Kind(
                modifier,
                kind);

            return output;
        }

        public bool Is_Volatile(SyntaxToken modifier)
        {
            var output = this.Is_Kind(
                modifier,
                SyntaxKind.VolatileKeyword);

            return output;
        }
    }
}
