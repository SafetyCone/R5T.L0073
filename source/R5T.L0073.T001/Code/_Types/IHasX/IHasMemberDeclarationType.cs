﻿using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0240;


namespace R5T.L0073.T001
{
    [HasXMarker]
    public interface IHasMemberDeclarationType<T> : IHasXMarker
        where T : MemberDeclarationSyntax
    {
        T MemberDeclaration { get; }
    }
}
