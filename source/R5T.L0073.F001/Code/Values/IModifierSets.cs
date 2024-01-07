using System;

using Microsoft.CodeAnalysis;

using R5T.T0131;


namespace R5T.L0073.F001
{
    [ValuesMarker]
    public partial interface IModifierSets : IValuesMarker
    {
        /// <summary>
        /// The empty modifier set.
        /// </summary>
        public SyntaxTokenList Empty => Instances.SyntaxGenerator.SyntaxTokenList();
    }
}
