using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.L0073.F001
{
    [FunctionalityMarker]
    public partial interface ISyntaxNodeOperator : IFunctionalityMarker
    {
        public bool Contains(
            SyntaxNode parentNode,
            SyntaxNode possibleChild)
        {
            var output = parentNode.Contains(possibleChild);
            return output;
        }

        public bool Contains(
            SyntaxNode node,
            SyntaxToken token)
        {
            var tokenParentNodeOrDefault = Instances.SyntaxTokenOperator.Get_ParentOrDefault(token);

            if(this.Is_Default(tokenParentNodeOrDefault))
            {
                return false;
            }
            // Else.

            var output = this.Contains(
                node,
                tokenParentNodeOrDefault);

            return output;
        }

        public IEnumerable<SyntaxToken> Enumerate_AnnotatedTokens(
            SyntaxNode node,
            SyntaxAnnotation annotation)
        {
            var output = node.GetAnnotatedTokens(annotation);
            return output;
        }

        public IEnumerable<SyntaxTrivia> Enumerate_AnnotatedTrivias(
            SyntaxNode node,
            SyntaxAnnotation annotation)
        {
            var output = node.GetAnnotatedTrivia(annotation);
            return output;
        }

        public IEnumerable<SyntaxNode> Enumerate_ChildNodes(SyntaxNode node)
        {
            var output = node.ChildNodes();
            return output;
        }

        public IEnumerable<SyntaxNode> Enumerate_DescendantNodes(SyntaxNode node)
        {
            var output = node.DescendantNodes();
            return output;
        }

        /// <summary>
        /// Enumerates descendant tokens.
        /// </summary>
        /// <remarks>
        /// This includes tokens in structured trivia, since those are in fact descendant tokens.
        /// </remarks>
        public IEnumerable<SyntaxToken> Enumerate_DescendantTokens(SyntaxNode node)
        {
            var output = node.DescendantTokens(
                descendIntoTrivia: true);

            return output;
        }

        /// <summary>
        /// Enumerates the descendant tokens that are not inside descendant structured trivia.
        /// </summary>
        /// <remarks>
        /// The default behavior of <see cref="SyntaxNode.DescendantTokens(Func{SyntaxNode, bool}?, bool)"/> is to not descend into structured trivia, which is confusing
        /// because it breaks the perception that all tokens in a code file are tokens.
        /// </remarks>
        public IEnumerable<SyntaxToken> Enumerate_DescendantTokens_NotInStructuredTrivia(SyntaxNode node)
        {
            var output = node.DescendantTokens(
                descendIntoTrivia: false);

            return output;
        }

        public IEnumerable<SyntaxTrivia> Enumerate_DescendantTrivias(SyntaxNode node)
        {
            var output = node.DescendantTrivia();
            return output;
        }

        public IEnumerable<SyntaxTrivia> Enumerate_DescendantTrivias(
            SyntaxNode node,
            SyntaxKind kind)
        {
            var output = this.Enumerate_DescendantTrivias(node)
                .Where(trivia => Instances.SyntaxTriviaOperator.Is_Kind(
                    trivia,
                    kind));

            return output;
        }

        public SyntaxNode[] Get_ChildNodes(SyntaxNode node)
        {
            var output = this.Enumerate_ChildNodes(node)
                .Now();

            return output;
        }

        public SyntaxToken Get_AnnotatedToken(
            SyntaxNode node,
            SyntaxAnnotation annotation)
        {
            return Instances.SyntaxAnnotationOperator.Get_AnnotatedToken(
                node,
                annotation);
        }

        public SyntaxTrivia Get_AnnotatedTrivia(
            SyntaxNode node,
            SyntaxAnnotation annotation)
        {
            return Instances.SyntaxAnnotationOperator.Get_AnnotatedTrivia(
                node,
                annotation);
        }

        public SyntaxNode[] Get_DescendantNodes(SyntaxNode node)
        {
            var output = this.Enumerate_DescendantNodes(node)
                .Now();

            return output;
        }

        public SyntaxToken[] Get_DescendantTokens(SyntaxNode node)
        {
            var output = this.Enumerate_DescendantTokens(node)
                .Now();

            return output;
        }

        public SyntaxTrivia[] Get_DescendantTrivias(SyntaxNode node)
        {
            var output = this.Enumerate_DescendantTrivias(node)
                .Now();

            return output;
        }

        public SyntaxTrivia[] Get_DescendantTrivias(
            SyntaxNode node,
            SyntaxKind kind)
        {
            var output = this.Enumerate_DescendantTrivias(
                node,
                kind)
                .Now();

            return output;
        }

        public SyntaxToken Get_FirstToken(SyntaxNode node)
        {
            var output = this.Enumerate_DescendantTokens(node)
                .First();

            return output;
        }

        public bool Has_AnnotatedToken(
            SyntaxNode node,
            SyntaxAnnotation annotation,
            out SyntaxToken annotatedTokenOrDefault)
        {
            return Instances.SyntaxAnnotationOperator.Has_AnnotatedToken(
                node,
                annotation,
                out annotatedTokenOrDefault);
        }

        public bool Is_Default(SyntaxNode node)
        {
            var output = Instances.DefaultOperator.Is_Default(node);
            return output;
        }

        public TNode Prepend_NewLine<TNode>(TNode node)
            where TNode : SyntaxNode
        {
            var output = this.Prepend_LeadingTrivias(
                node,
                Instances.SyntaxTrivias.Whitespace_EndOfLine);

            return output;
        }

        public TNode Prepend_BlankLine<TNode>(TNode node)
            where TNode : SyntaxNode
        {
            var output = this.Prepend_LeadingTrivias(
                node,
                Instances.SyntaxTrivias.Whitespace_EndOfLine,
                Instances.SyntaxTrivias.Whitespace_EndOfLine);

            return output;
        }

        public TNode Prepend_Space<TNode>(TNode node)
            where TNode : SyntaxNode
        {
            var output = this.Prepend_LeadingTrivias(
                node,
                Instances.SyntaxTrivias.Whitespace_Space);

            return output;
        }

        public TNode Prepend_TwoBlankLines<TNode>(TNode node)
            where TNode : SyntaxNode
        {
            var output = this.Prepend_LeadingTrivias(
                node,
                Instances.SyntaxTrivias.Whitespace_EndOfLine,
                Instances.SyntaxTrivias.Whitespace_EndOfLine,
                Instances.SyntaxTrivias.Whitespace_EndOfLine);

            return output;
        }

        public TNode Prepend_LeadingTrivias<TNode>(
            TNode node,
            IEnumerable<SyntaxTrivia> trivias)
            where TNode : SyntaxNode
        {
            var output = node.WithLeadingTrivia(
                node.GetLeadingTrivia()
                    .Prepend(trivias));

            return output;
        }

        public TNode Prepend_LeadingTrivias<TNode>(
            TNode node,
            params SyntaxTrivia[] trivias)
            where TNode : SyntaxNode
        {
            var output = this.Prepend_LeadingTrivias(
                node,
                trivias.AsEnumerable());

            return output;
        }

        public TNode Remove_LeadingTrivia<TNode>(TNode node)
            where TNode : SyntaxNode
        {
            var output = node.WithLeadingTrivia();
            return output;

            //// Removoing leading or trailing trivia from a node is a little tricky because nodes do not actually have trivia;
            //// only the tokens the node is composed of have trivia.
            //// Thus we need to get the first token, remove its trivia, and replace it.
            //var firstToken = this.Get_FirstToken(node);

            //var modifiedFirstToken = Instances.SyntaxTokenOperator.Remove_LeadingTrivia(firstToken);

            //var output = this.Replace_Token(
            //    node,
            //    firstToken,
            //    modifiedFirstToken);

            //return output;
        }

        /// <summary>
        /// Chooses <see cref="Replace_Token_Better{TNode}(TNode, SyntaxToken, SyntaxToken)"/> as the default.
        /// </summary>
        public TNode Replace_Token<TNode>(
            TNode node,
            SyntaxToken tokenToReplace,
            SyntaxToken newToken)
            where TNode : SyntaxNode
        {
            return this.Replace_Token_Better(
                node,
                tokenToReplace,
                newToken);
        }

        /// <summary>
        /// A better version of <see cref="Microsoft.CodeAnalysis.SyntaxNodeExtensions.ReplaceToken{TRoot}(TRoot, SyntaxToken, SyntaxToken)"/>
        /// that will throw an exception if the input token is not found.
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Y000.Documentation.ForSyntaxNode.ReplaceMethodsDoNotErrorIfNotFound" path="/summary"/>
        /// </remarks>
        public TNode Replace_Token_Better<TNode>(
            TNode node,
            SyntaxToken tokenToReplace,
            SyntaxToken newToken)
            where TNode : SyntaxNode
        {
            var tokenWasFound = false;

            var output = node.ReplaceTokens(
                Instances.EnumerableOperator.From(tokenToReplace),
                (originalToken, possiblyRewrittenToken) =>
                {
                    if (originalToken == tokenToReplace)
                    {
                        tokenWasFound = true;
                    }

                    return newToken;
                });

            if (!tokenWasFound)
            {
                throw new Exception("Token was not found.");
            }

            return output;
        }

        /// <summary>
        /// Chooses <see cref="Replace_Tokens_Better{TNode}(TNode, IEnumerable{SyntaxToken}, Func{SyntaxToken, SyntaxToken, SyntaxToken})"/> as the default replace tokens method.
        /// </summary>
        public TNode Replace_Tokens<TNode>(
            TNode node,
            IEnumerable<SyntaxToken> tokensToReplace,
            Func<SyntaxToken, SyntaxToken, SyntaxToken> computeReplacementToken)
            where TNode : SyntaxNode
        {
            return this.Replace_Tokens_Better(
                node,
                tokensToReplace,
                computeReplacementToken);
        }

        /// <summary>
        /// A better version of <see cref="Microsoft.CodeAnalysis.SyntaxNodeExtensions.ReplaceTokens{TRoot}(TRoot, IEnumerable{SyntaxToken}, Func{SyntaxToken, SyntaxToken, SyntaxToken})"/>
        /// that will throw an exception if any of the input tokens are not found.
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Y000.Documentation.ForSyntaxNode.ReplaceMethodsDoNotErrorIfNotFound" path="/summary"/>
        /// </remarks>
        public TNode Replace_Tokens_Better<TNode>(
            TNode node,
            IEnumerable<SyntaxToken> tokensToReplace,
            Func<SyntaxToken, SyntaxToken, SyntaxToken> computeReplacementToken)
            where TNode : SyntaxNode
        {
            var inputTokensHash = new HashSet<SyntaxToken>(tokensToReplace);

            var output = node.ReplaceTokens(
                tokensToReplace,
                (originalToken, possiblyRewrittenToken) =>
                {
                    // Remove the original token.
                    inputTokensHash.Remove(originalToken);

                    // Compute the replacement token.
                    var replacementToken = computeReplacementToken(originalToken, possiblyRewrittenToken);
                    return replacementToken;
                });

            if(inputTokensHash.Any())
            {
                throw new Exception($"Some tokens to replace were not found. Count: {inputTokensHash.Count}.");
            }

            return output;
        }

        public TNode Replace_Tokens_Better<TNode>(
            TNode node,
            IDictionary<SyntaxToken, SyntaxToken> replacementsByOriginalToken)
            where TNode : SyntaxNode
        {
            var output = this.Replace_Tokens_Better(
                node,
                replacementsByOriginalToken.Keys,
                (originalToken, _) => replacementsByOriginalToken[originalToken]);

            return output;
        }

        public TNode Replace_Tokens_Better<TNode>(
            TNode node,
            IEnumerable<(SyntaxToken OriginalToken, SyntaxToken ReplacementToken)> replacementPairs)
            where TNode : SyntaxNode
        {
            var replacementsDictionary = replacementPairs
                .ToDictionary(
                    x => x.OriginalToken,
                    x => x.ReplacementToken);

            var output = this.Replace_Tokens_Better(
                node,
                replacementsDictionary);

            return output;
        }


        /// <summary>
        /// A better version of <see cref="Microsoft.CodeAnalysis.SyntaxNodeExtensions.ReplaceTrivia{TRoot}(TRoot, IEnumerable{SyntaxTrivia}, Func{SyntaxTrivia, SyntaxTrivia, SyntaxTrivia})"/>
        /// that will throw an exception if any of the input tokens are not found.
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Y000.Documentation.ForSyntaxNode.ReplaceMethodsDoNotErrorIfNotFound" path="/summary"/>
        /// </remarks>
        public TNode Replace_Trivias_Better<TNode>(
            TNode node,
            IEnumerable<SyntaxTrivia> triviasToReplace,
            Func<SyntaxTrivia, SyntaxTrivia, SyntaxTrivia> computeReplacementTrivia)
            where TNode : SyntaxNode
        {
            var inputTriviasHash = new HashSet<SyntaxTrivia>(triviasToReplace);

            var output = node.ReplaceTrivia(
                triviasToReplace,
                (originalTrivia, possiblyRewrittenTrivia) =>
                {
                    // Remove the original token.
                    inputTriviasHash.Remove(originalTrivia);

                    // Compute the replacement token.
                    var replacementTrivia = computeReplacementTrivia(originalTrivia, possiblyRewrittenTrivia);
                    return replacementTrivia;
                });

            if (inputTriviasHash.Any())
            {
                throw new Exception($"Some trivias to replace were not found. Count: {inputTriviasHash.Count}.");
            }

            return output;
        }

        public TNode Replace_Trivias_Better<TNode>(
            TNode node,
            IDictionary<SyntaxTrivia, SyntaxTrivia> replacementsByOriginalTrivia)
            where TNode : SyntaxNode
        {
            var output = this.Replace_Trivias_Better(
                node,
                replacementsByOriginalTrivia.Keys,
                (originalTrivia, _) => replacementsByOriginalTrivia[originalTrivia]);

            return output;
        }

        public TNode Replace_Trivias_Better<TNode>(
            TNode node,
            IEnumerable<(SyntaxTrivia OriginalTrivia, SyntaxTrivia ReplacementTrivia)> replacementPairs)
            where TNode : SyntaxNode
        {
            var replacementsDictionary = replacementPairs
                .ToDictionary(
                    x => x.OriginalTrivia,
                    x => x.ReplacementTrivia);

            var output = this.Replace_Trivias_Better(
                node,
                replacementsDictionary);

            return output;
        }

        /// <summary>
        /// Chooses <see cref="Replace_Trivia_Better{TNode}(TNode, SyntaxTrivia, SyntaxTrivia)"/> as the default.
        /// </summary>
        public TNode Replace_Trivia<TNode>(
            TNode node,
            SyntaxTrivia triviaToReplace,
            SyntaxTrivia newTrivia)
            where TNode : SyntaxNode
        {
            return this.Replace_Trivia_Better(
                node,
                triviaToReplace,
                newTrivia);
        }

        /// <summary>
        /// A better version of <see cref="Microsoft.CodeAnalysis.SyntaxNodeExtensions.ReplaceTrivia{TRoot}(TRoot, SyntaxTrivia, SyntaxTrivia)"/>
        /// that will throw an exception if the input trivia is not found.
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Y000.Documentation.ForSyntaxNode.ReplaceMethodsDoNotErrorIfNotFound" path="/summary"/>
        /// </remarks>
        public TNode Replace_Trivia_Better<TNode>(
            TNode node,
            SyntaxTrivia triviaToReplace,
            SyntaxTrivia newTrivia)
            where TNode : SyntaxNode
        {
            var triviaWasFound = false;

            var output = node.ReplaceTrivia(
                Instances.EnumerableOperator.From(triviaToReplace),
                (originalTrivia, possiblyRewrittenTrivia) =>
                {
                    if (originalTrivia == triviaToReplace)
                    {
                        triviaWasFound = true;
                    }

                    return newTrivia;
                });

            if (!triviaWasFound)
            {
                throw new Exception("Trivia was not found.");
            }

            return output;
        }

        /// <summary>
        /// A better version of <see cref="Microsoft.CodeAnalysis.SyntaxNodeExtensions.ReplaceNodes{TRoot, TNode}(TRoot, IEnumerable{TNode}, Func{TNode, TNode, SyntaxNode})"/>
        /// that will throw an exception if any of the input nodes are not found.
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Y000.Documentation.ForSyntaxNode.ReplaceMethodsDoNotErrorIfNotFound" path="/summary"/>
        /// </remarks>
        public TNode Replace_Nodes_Better<TNode>(
            TNode node,
            IEnumerable<SyntaxNode> nodesToReplace,
            Func<SyntaxNode, SyntaxNode, SyntaxNode> computeReplacementNode)
            where TNode : SyntaxNode
        {
            var inputNodesHash = new HashSet<SyntaxNode>(nodesToReplace);

            var output = node.ReplaceNodes(
                nodesToReplace,
                (originalNode, possiblyRewrittenNode) =>
                {
                    // Remove the original token.
                    inputNodesHash.Remove(originalNode);

                    // Compute the replacement token.
                    var replacementNode = computeReplacementNode(originalNode, possiblyRewrittenNode);
                    return replacementNode;
                });

            if (inputNodesHash.Any())
            {
                throw new Exception($"Some trivias to replace were not found. Count: {inputNodesHash.Count}.");
            }

            return output;
        }

        public TNode Replace_Nodes_Better<TNode>(
            TNode node,
            IDictionary<SyntaxNode, SyntaxNode> replacementsByOriginalNode)
            where TNode : SyntaxNode
        {
            var output = this.Replace_Nodes_Better(
                node,
                replacementsByOriginalNode.Keys,
                (originalTrivia, _) => replacementsByOriginalNode[originalTrivia]);

            return output;
        }

        public TNode Replace_Nodes_Better<TNode>(
            TNode node,
            IEnumerable<(SyntaxNode OriginalTrivia, SyntaxNode ReplacementTrivia)> replacementPairs)
            where TNode : SyntaxNode
        {
            var replacementsDictionary = replacementPairs
                .ToDictionary(
                    x => x.OriginalTrivia,
                    x => x.ReplacementTrivia);

            var output = this.Replace_Nodes_Better(
                node,
                replacementsDictionary);

            return output;
        }

        /// <summary>
        /// Chooses <see cref="Replace_Trivia_Better{TNode}(TNode, SyntaxTrivia, SyntaxTrivia)"/> as the default.
        /// </summary>
        public TNode Replace_Node<TNode>(
            TNode node,
            SyntaxNode nodeToReplace,
            SyntaxNode newNode)
            where TNode : SyntaxNode
        {
            return this.Replace_Node_Better(
                node,
                nodeToReplace,
                newNode);
        }

        /// <summary>
        /// A better version of <see cref="Microsoft.CodeAnalysis.SyntaxNodeExtensions.ReplaceNode{TRoot}(TRoot, SyntaxNode, SyntaxNode)"/>
        /// that will throw an exception if the input node is not found.
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Y000.Documentation.ForSyntaxNode.ReplaceMethodsDoNotErrorIfNotFound" path="/summary"/>
        /// </remarks>
        public TNode Replace_Node_Better<TNode>(
            TNode node,
            SyntaxNode nodeToReplace,
            SyntaxNode newNode)
            where TNode : SyntaxNode
        {
            var nodeWasFound = false;

            var output = node.ReplaceNodes(
                Instances.EnumerableOperator.From(nodeToReplace),
                (originalNode, possiblyRewrittenNode) =>
                {
                    if (originalNode == nodeToReplace)
                    {
                        nodeWasFound = true;
                    }

                    return newNode;
                });

            if (!nodeWasFound)
            {
                throw new Exception("Node was not found.");
            }

            return output;
        }
    }
}
