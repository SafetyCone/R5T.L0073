using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.L0073.F001
{
    public class BlockSyntaxWrapper :
        IWithBraceTokens
    {
        public BlockSyntax BlockSyntax { get; set; }

        public SyntaxToken OpenBraceToken
        {
            get
            {
                return this.BlockSyntax.OpenBraceToken;
            }
            set
            {
                this.BlockSyntax = this.BlockSyntax.WithOpenBraceToken(value);
            }
        }

        public SyntaxToken CloseBraceToken
        {
            get
            {
                return this.BlockSyntax.CloseBraceToken;
            }
            set
            {
                this.BlockSyntax = this.BlockSyntax.WithCloseBraceToken(value);
            }
        }


        public BlockSyntaxWrapper(BlockSyntax blockSyntax)
        {
            this.BlockSyntax = blockSyntax;
        }
    }
}
