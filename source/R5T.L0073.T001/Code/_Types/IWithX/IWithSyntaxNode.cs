using System;

using Microsoft.CodeAnalysis;

using R5T.T0240;


namespace R5T.L0073.T001
{
    /// <inheritdoc cref="IHasSyntaxNode{TSyntaxNode}"/>
    [WithXMarker]
    public interface IWithSyntaxNode<TSyntaxNode> : IWithXMarker,
        IHasSyntaxNode<TSyntaxNode>
        where TSyntaxNode : SyntaxNode
    {
        new TSyntaxNode SyntaxNode { get; set; }
    }
}
