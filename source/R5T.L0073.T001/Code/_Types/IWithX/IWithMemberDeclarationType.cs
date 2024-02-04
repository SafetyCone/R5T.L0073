﻿using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0240;


namespace R5T.L0073.T001
{
    [WithXMarker]
    public interface IWithMemberDeclarationType<T> : IWithXMarker,
        IHasMemberDeclarationType<T>
        where T : MemberDeclarationSyntax
    {
        new T MemberDeclaration { get; set; }
    }
}