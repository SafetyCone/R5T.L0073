using System;

using Microsoft.CodeAnalysis;

using R5T.T0240;


namespace R5T.L0073.T001
{
    /// <inheritdoc cref="IHasPrimarySyntaxNode{TSyntaxNode}"/>
    [WithXMarker]
    public interface IWithPrimarySyntaxNode<TSyntaxNode> : IWithXMarker,
        IHasPrimarySyntaxNode<TSyntaxNode>
        where TSyntaxNode : SyntaxNode
    {
        new TSyntaxNode SyntaxNode { get; set; }
    }
}
