using System;

using Microsoft.CodeAnalysis;

using R5T.T0240;


namespace R5T.L0073.T001
{
    /// <summary>
    /// Has a generically typed Roslyn syntax node that is the primary syntax node.
    /// This is in conjunction with <see cref="IHasSyntaxNode{TSyntaxNode}"/>, and used when the CS0695 unified type parameter substitutions issue raises its ugly head.
    /// </summary>
    /// <typeparam name="TSyntaxNode">The <see cref="Microsoft.CodeAnalysis.SyntaxNode"/>-restriced type.</typeparam>
    [HasXMarker]
    public interface IHasPrimarySyntaxNode<TSyntaxNode> : IHasXMarker
        where TSyntaxNode : SyntaxNode
    {
        TSyntaxNode SyntaxNode { get; }
    }
}
