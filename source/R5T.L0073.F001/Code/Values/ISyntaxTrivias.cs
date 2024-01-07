using System;

using Microsoft.CodeAnalysis;

using R5T.T0131;


namespace R5T.L0073.F001
{
    [ValuesMarker]
    public partial interface ISyntaxTrivias : IValuesMarker
    {
        /// <summary>
        /// A trivia in its initial (zero) state.
        /// </summary>
        public SyntaxTrivia Initial => Instances.SyntaxTriviaOperator.New();

        public SyntaxTrivia Whitespace_Empty => Instances.SyntaxTriviaOperator.New_Whitespace(
            Instances.Strings.Empty);

        public SyntaxTrivia Whitespace_Space => Instances.SyntaxTriviaOperator.New_Whitespace(
            Instances.Strings.Space);

        /// <summary>
        /// Get a whitespace tab (as a single character).
        /// <inheritdoc cref="L0066.IStrings.Tab" path="/summary"/>
        /// </summary>
        public SyntaxTrivia Whitespace_Tab_Character => Instances.SyntaxTriviaOperator.New_Whitespace(
            Instances.Strings.Tab);

        /// <summary>
        /// Get a whitespace tab as spaces.
        /// <inheritdoc cref="L0066.IStrings.Tab_AsSpaces" path="/summary"/>
        /// </summary>
        public SyntaxTrivia Whitespace_Tab_Spaces => Instances.SyntaxTriviaOperator.New_Whitespace(
            Instances.Strings.Tab_AsSpaces);

        /// <inheritdoc cref="Whitespace_Tab_Spaces"/>
        public SyntaxTrivia Whitespace_Tab => this.Whitespace_Tab_Spaces;

        /// <summary>
        /// Uses <see cref="L0066.IStrings.NewLine_ForEnvironment"/>.
        /// </summary>
        public SyntaxTrivia Whitespace_EndOfLine => Instances.SyntaxTriviaOperator.New_EndOfLine(
            Instances.Strings.NewLine_ForEnvironment);
    }
}
