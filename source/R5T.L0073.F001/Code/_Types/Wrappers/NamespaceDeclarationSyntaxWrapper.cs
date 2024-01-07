using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.L0073.F001
{
    public class NamespaceDeclarationSyntaxWrapper :
        IHasMembers,
        IWithBraceTokens
    {
        public NamespaceDeclarationSyntax NamespaceDeclarationSyntax { get; set; }

        public SyntaxToken OpenBraceToken
        {
            get
            {
                return this.NamespaceDeclarationSyntax.OpenBraceToken;
            }
            set
            {
                this.NamespaceDeclarationSyntax = this.NamespaceDeclarationSyntax.WithOpenBraceToken(value);
            }
        }

        public SyntaxToken CloseBraceToken
        {
            get
            {
                return this.NamespaceDeclarationSyntax.CloseBraceToken;
            }
            set
            {
                this.NamespaceDeclarationSyntax = this.NamespaceDeclarationSyntax.WithCloseBraceToken(value);
            }
        }

        public SyntaxList<MemberDeclarationSyntax> Members => this.NamespaceDeclarationSyntax.Members;


        public NamespaceDeclarationSyntaxWrapper(NamespaceDeclarationSyntax namespaceDeclarationSyntax)
        {
            this.NamespaceDeclarationSyntax = namespaceDeclarationSyntax;
        }
    }
}
