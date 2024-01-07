using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.L0073.F001
{
    public class BaseTypeDeclarationSyntaxWrapper :
        IWithBraceTokens
    {
        public BaseTypeDeclarationSyntax BaseTypeDeclarationSyntax { get; set; }

        public SyntaxToken OpenBraceToken
        {
            get
            {
                return this.BaseTypeDeclarationSyntax.OpenBraceToken;
            }
            set
            {
                this.BaseTypeDeclarationSyntax = this.BaseTypeDeclarationSyntax.WithOpenBraceToken(value);
            }
        }

        public SyntaxToken CloseBraceToken
        {
            get
            {
                return this.BaseTypeDeclarationSyntax.CloseBraceToken;
            }
            set
            {
                this.BaseTypeDeclarationSyntax = this.BaseTypeDeclarationSyntax.WithCloseBraceToken(value);
            }
        }


        public BaseTypeDeclarationSyntaxWrapper(BaseTypeDeclarationSyntax baseTypeDeclarationSyntax)
        {
            this.BaseTypeDeclarationSyntax = baseTypeDeclarationSyntax;
        }
    }
}
