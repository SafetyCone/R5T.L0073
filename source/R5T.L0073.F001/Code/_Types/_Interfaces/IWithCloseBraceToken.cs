using System;

using Microsoft.CodeAnalysis;


namespace R5T.L0073.F001
{
    public interface IWithCloseBraceToken :
        IHasCloseBraceToken
    {
        new SyntaxToken CloseBraceToken { get; set; }
    }
}
