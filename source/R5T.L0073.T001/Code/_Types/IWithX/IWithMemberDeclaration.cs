using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0240;


namespace R5T.L0073.T001
{
    [WithXMarker]
    public interface IWithMemberDeclaration : IWithXMarker,
        IHasMemberDeclaration
    {
        new MemberDeclarationSyntax MemberDeclaration { get; set; }
    }
}
