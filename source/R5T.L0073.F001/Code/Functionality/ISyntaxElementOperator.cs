using System;

using Microsoft.CodeAnalysis;

using R5T.T0132;


namespace R5T.L0073.F001
{
    [FunctionalityMarker]
    public partial interface ISyntaxElementOperator : IFunctionalityMarker
    {
        public SyntaxNodeSyntaxElement From(SyntaxNode node)
        {
            var output = new SyntaxNodeSyntaxElement(node);
            return output;
        }

        public SyntaxTokenSyntaxElement From(SyntaxToken token)
        {
            var output = new SyntaxTokenSyntaxElement(token);
            return output;
        }

        public SyntaxTriviaSyntaxElement From(SyntaxTrivia trivia)
        {
            var output = new SyntaxTriviaSyntaxElement(trivia);
            return output;
        }

        public void Switch_OnSyntaxElementType(
            SyntaxElement element,
            Action<SyntaxNode> nodeAction,
            Action<SyntaxToken> tokenAction,
            Action<SyntaxTrivia> triviaAction)
        {
            // Switch expression on type must return a value, but this can be an action that is immediately executed.
            Action action = element switch
            {
                SyntaxNodeSyntaxElement syntaxNodeElement => () => nodeAction(syntaxNodeElement.Node),
                SyntaxTokenSyntaxElement syntaxTokenElement => () => tokenAction(syntaxTokenElement.Token),
                SyntaxTriviaSyntaxElement syntaxTriviaElement => () => triviaAction(syntaxTriviaElement.Trivia),
                _ => throw new Exception()
            };

            action();
        }
    }
}
