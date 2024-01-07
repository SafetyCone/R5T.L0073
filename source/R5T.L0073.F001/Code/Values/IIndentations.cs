using System;

using Microsoft.CodeAnalysis;

using R5T.T0131;


namespace R5T.L0073.F001
{
    /// <summary>
    /// Indentation is a trivia list <em>without</em> a leading new line.
    /// </summary>
    [ValuesMarker]
    public partial interface IIndentations : IValuesMarker
    {
        public SyntaxTriviaList Tab => Instances.SyntaxTriviaLists.Tab;
    }
}
