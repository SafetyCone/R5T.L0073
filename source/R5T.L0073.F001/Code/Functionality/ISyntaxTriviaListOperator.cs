using System;
using System.Linq;

using Microsoft.CodeAnalysis;

using R5T.T0132;


namespace R5T.L0073.F001
{
    [FunctionalityMarker]
    public partial interface ISyntaxTriviaListOperator : IFunctionalityMarker
    {
        public bool Contains(
            SyntaxTriviaList trivias,
            SyntaxTrivia trivia)
        {
            var output = trivias.Contains(trivia);
            return output;
        }

        public SyntaxTriviaList Insert_After(
            SyntaxTriviaList trivias,
            SyntaxTrivia triviaToInsertAfter,
            SyntaxTriviaList insertion)
        {
            var indexOfInsertAfter = trivias.IndexOf(triviaToInsertAfter);

            var output = trivias.InsertRange(
                indexOfInsertAfter + 1,
                insertion);

            return output;
        }

        public SyntaxTriviaList New()
        {
            var output = new SyntaxTriviaList();
            return output;
        }

        public SyntaxTriviaList New(
            params SyntaxTrivia[] syntaxTrivias)
        {
            var output = new SyntaxTriviaList(syntaxTrivias);
            return output;
        }

        public SyntaxTriviaList Prepend(
            SyntaxTriviaList trivias,
            SyntaxTriviaList prependix)
        {
            var output = new SyntaxTriviaList(
                prependix.AsEnumerable()
                    .Concat(trivias));

            return output;
        }
    }
}
