using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

using R5T.T0132;


namespace R5T.L0073.F001
{
    /// <summary>
    /// Syntax annotation-specific functionality.
    /// </summary>
    // Prior work: R5T.E0068, R5T.L0011.X000.
    [FunctionalityMarker]
    public partial interface ISyntaxAnnotationOperator : IFunctionalityMarker
    {
        public SyntaxToken Annotate(
            SyntaxToken token,
            out SyntaxAnnotation annotation)
        {
            annotation = this.New();

            var annotatedToken = token.WithAdditionalAnnotations(
                annotation);

            return annotatedToken;
        }

        public SyntaxTrivia Annotate(
            SyntaxTrivia trivia,
            out SyntaxAnnotation annotation)
        {
            annotation = this.New();

            var annotatedTrivia = trivia.WithAdditionalAnnotations(
                annotation);

            return annotatedTrivia;
        }

        public TNode AnnotateTokens<TNode>(
            TNode node,
            IEnumerable<SyntaxToken> tokens,
            out Dictionary<SyntaxToken, SyntaxAnnotation> annotationsByInputToken)
            where TNode : SyntaxNode
        {
            // Temporary variable is required for use in anonymous method below.
            var annotationsByInputToken_Temp = new Dictionary<SyntaxToken, SyntaxAnnotation>();

            var output = Instances.SyntaxNodeOperator.Replace_Tokens_Better(
                node,
                tokens,
                (originalToken, possiblyRewrittenToken) =>
                {
                    var outputToken = this.Annotate(
                        possiblyRewrittenToken,
                        out var annotation);

                    annotationsByInputToken_Temp.Add(
                        // Use the original token so that the annotation for it that only exists on the new token can be found.
                        originalToken,
                        annotation);

                    return outputToken;
                });

            annotationsByInputToken = annotationsByInputToken_Temp;

            return output;
        }

        public TNode AnnotateTrivias<TNode>(
            TNode node,
            IEnumerable<SyntaxTrivia> trivias,
            out Dictionary<SyntaxTrivia, SyntaxAnnotation> annotationsByInputTrivia)
            where TNode : SyntaxNode
        {
            // Temporary variable is required for use in anonymous method below.
            var annotationsByInputToken_Temp = new Dictionary<SyntaxTrivia, SyntaxAnnotation>();

            var output = Instances.SyntaxNodeOperator.Replace_Trivias_Better(
                node,
                trivias,
                (originalTrivia, possiblyRewrittenTrivia) =>
                {
                    var outputToken = this.Annotate(
                        possiblyRewrittenTrivia,
                        out var annotation);

                    annotationsByInputToken_Temp.Add(
                        // Use the original token so that the annotation for it that only exists on the new token can be found.
                        originalTrivia,
                        annotation);

                    return outputToken;
                });

            annotationsByInputTrivia = annotationsByInputToken_Temp;

            return output;
        }

        public SyntaxToken Get_AnnotatedToken(
            SyntaxNode node,
            SyntaxAnnotation annotation)
        {
            var hasAnnotatedToken = this.Has_AnnotatedToken(
                node,
                annotation,
                out var annotatedToken);

            if(!hasAnnotatedToken)
            {
                throw new Exception("No token with annotation found.");
            }

            return annotatedToken;
        }

        public SyntaxTrivia Get_AnnotatedTrivia(
            SyntaxNode node,
            SyntaxAnnotation annotation)
        {
            var hasAnnotatedTrivia = this.Has_AnnotatedTrivia(
                node,
                annotation,
                out var annotatedTrivia);

            if (!hasAnnotatedTrivia)
            {
                throw new Exception("No trivia with annotation found.");
            }

            return annotatedTrivia;
        }

        /// <summary>
        /// Chooses <see cref="Has_AnnotatedToken_Single(SyntaxNode, SyntaxAnnotation, out SyntaxToken)"/> as the default.
        /// </summary>
        public bool Has_AnnotatedToken(
            SyntaxNode node,
            SyntaxAnnotation annotation,
            out SyntaxToken annotatedTokenOrDefault)
        {
            return this.Has_AnnotatedToken_Single(
                node,
                annotation,
                out annotatedTokenOrDefault);
        }

        public bool Has_AnnotatedToken_Single(
            SyntaxNode node,
            SyntaxAnnotation annotation,
            out SyntaxToken annotatedTokenOrDefault)
        {
            annotatedTokenOrDefault = Instances.SyntaxNodeOperator.Enumerate_AnnotatedTokens(
                node,
                annotation)
                .SingleOrDefault();

            var output = Instances.SyntaxTokenOperator.Is_NotDefault(annotatedTokenOrDefault);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Has_AnnotatedToken_Single(SyntaxNode, SyntaxAnnotation, out SyntaxToken)"/> as the default.
        /// </summary>
        public bool Has_AnnotatedTrivia(
            SyntaxNode node,
            SyntaxAnnotation annotation,
            out SyntaxTrivia annotatedTriviaOrDefault)
        {
            return this.Has_AnnotatedTrivia_Single(
                node,
                annotation,
                out annotatedTriviaOrDefault);
        }

        public bool Has_AnnotatedTrivia_Single(
            SyntaxNode node,
            SyntaxAnnotation annotation,
            out SyntaxTrivia annotatedTriviaOrDefault)
        {
            annotatedTriviaOrDefault = Instances.SyntaxNodeOperator.Enumerate_AnnotatedTrivias(
                node,
                annotation)
                .SingleOrDefault();

            var output = Instances.SyntaxTriviaOperator.Is_NotDefault(annotatedTriviaOrDefault);
            return output;
        }

        public SyntaxAnnotation New()
        {
            var output = new SyntaxAnnotation();
            return output;
        }
    }
}
