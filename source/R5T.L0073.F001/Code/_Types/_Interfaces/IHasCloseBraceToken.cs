using System;

using Microsoft.CodeAnalysis;


namespace R5T.L0073.F001
{
    public interface IHasCloseBraceToken
    {
        SyntaxToken CloseBraceToken { get; }
    }
}
