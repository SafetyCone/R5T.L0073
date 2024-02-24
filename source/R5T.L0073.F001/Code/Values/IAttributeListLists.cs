using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.L0073.F001
{
    [ValuesMarker]
    public partial interface IAttributeListLists : IValuesMarker
    {
        public SyntaxList<AttributeListSyntax> Empty => Instances.SyntaxGenerator.SyntaxList<AttributeListSyntax>();
    }
}
