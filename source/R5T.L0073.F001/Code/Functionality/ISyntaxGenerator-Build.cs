using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.L0073.F001
{
    public partial interface ISyntaxGenerator : IFunctionalityMarker
    {
        public TNode Build<TNode>(
            Func<TNode> constructor,
            IEnumerable<Func<TNode, TNode>> operations)
            where TNode : SyntaxNode
        {
            var initial = constructor();

            return this.Build(
                initial,
                operations);
        }

        public TNode Build<TNode>(
            Func<TNode> constructor,
            params Func<TNode, TNode>[] operations)
            where TNode : SyntaxNode
        {
            return this.Build(
                constructor,
                operations.AsEnumerable());
        }

        public TNode Build<TNode>(
            TNode initial,
            IEnumerable<Func<TNode, TNode>> operations)
            where TNode : SyntaxNode
        {
            var output = Instances.FunctionOperator.Run_Modifiers(
                initial,
                operations);

            return output;
        }

        public TNode Build<TNode>(
            TNode initial,
            params Func<TNode, TNode>[] operations)
            where TNode : SyntaxNode
        {
            return this.Build(
                initial,
                operations.AsEnumerable());
        }
    }
}
