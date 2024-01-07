using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.L0073.F001
{
    [FunctionalityMarker]
    public partial interface IWithBraceTokensOperator : IFunctionalityMarker
    {
        public void Set_LeadingTrivias_Initial(IWithBraceTokens withBraceTokens)
        {
            withBraceTokens.OpenBraceToken = Instances.SyntaxTokenOperator.Prepend_NewLine(withBraceTokens.OpenBraceToken);
            withBraceTokens.CloseBraceToken = Instances.SyntaxTokenOperator.Prepend_NewLine(withBraceTokens.CloseBraceToken);
        }

        public TBaseTypeDeclarationSyntax Set_LeadingTrivias_Initial<TBaseTypeDeclarationSyntax>(TBaseTypeDeclarationSyntax namespaceDeclaration)
            where TBaseTypeDeclarationSyntax : BaseTypeDeclarationSyntax
        {
            var withBraceTokens = new BaseTypeDeclarationSyntaxWrapper(namespaceDeclaration);

            this.Set_LeadingTrivias_Initial(withBraceTokens);

            return withBraceTokens.BaseTypeDeclarationSyntax as TBaseTypeDeclarationSyntax;
        }

        public NamespaceDeclarationSyntax Set_LeadingTrivias_Initial(NamespaceDeclarationSyntax namespaceDeclaration)
        {
            var withBraceTokens = new NamespaceDeclarationSyntaxWrapper(namespaceDeclaration);

            this.Set_LeadingTrivias_Initial(withBraceTokens);

            return withBraceTokens.NamespaceDeclarationSyntax;
        }
    }
}
