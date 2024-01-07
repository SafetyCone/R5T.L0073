using System;

using Microsoft.CodeAnalysis;

using R5T.T0131;


namespace R5T.L0073.F001
{
    [ValuesMarker]
    public partial interface ISyntaxNodeOperations : IValuesMarker
    {
        public TNode Move_DescendantTrailingTriviaToLeadingTrivia<TNode>(TNode node)
            where TNode : SyntaxNode
        {
            return Instances.SyntaxNodeOperator_Utilities.Move_DescendantTrailingTriviaToLeadingTrivia(node);
        }
    }
}
