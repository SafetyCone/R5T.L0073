using System;

using Microsoft.CodeAnalysis;

using R5T.T0240;


namespace R5T.L0073.T001
{
    /// <summary>
    /// Has a generically typed Roslyn syntax node.
    /// </summary>
    /// <typeparam name="TSyntaxNode">The <see cref="Microsoft.CodeAnalysis.SyntaxNode"/>-restriced type.</typeparam>
    [HasXMarker]
    public interface IHasSyntaxNode<TSyntaxNode> : IHasXMarker
        where TSyntaxNode : SyntaxNode
    {
        TSyntaxNode SyntaxNode { get; }
    }
}
