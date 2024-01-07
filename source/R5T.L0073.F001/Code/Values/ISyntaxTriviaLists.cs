using System;

using Microsoft.CodeAnalysis;

using R5T.T0131;


namespace R5T.L0073.F001
{
    [ValuesMarker]
    public partial interface ISyntaxTriviaLists : IValuesMarker
    {
        /// <summary>
        /// A new, empty (zero-element) syntax trivia list.
        /// </summary>
        public SyntaxTriviaList Empty => Instances.SyntaxTriviaListOperator.New();

        /// <inheritdoc cref="ISyntaxTrivias.Whitespace_EndOfLine"/>
        public SyntaxTriviaList NewLine => Instances.SyntaxTriviaListOperator.New(
            Instances.SyntaxTrivias.Whitespace_EndOfLine);

        /// <summary>
        /// A single space.
        /// </summary>
        public SyntaxTriviaList Space => Instances.SyntaxTriviaListOperator.New(
            Instances.SyntaxTrivias.Whitespace_Space);

        /// <summary>
        /// A single tab.
        /// <para><inheritdoc cref="ISyntaxTrivias.Whitespace_Tab" path="/summary"/></para>
        /// </summary>
        public SyntaxTriviaList Tab => Instances.SyntaxTriviaListOperator.New(
            Instances.SyntaxTrivias.Whitespace_Tab);
    }
}
