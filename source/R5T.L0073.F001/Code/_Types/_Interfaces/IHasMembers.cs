using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.L0073.F001
{
    public interface IHasMembers
    {
        SyntaxList<MemberDeclarationSyntax> Members { get; }
    }
}
