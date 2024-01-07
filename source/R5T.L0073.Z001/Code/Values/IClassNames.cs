using System;

using Microsoft.CodeAnalysis;

using R5T.T0131;


namespace R5T.L0073.Z001
{
    [ValuesMarker]
    public partial interface IClassNames : IValuesMarker
    {
        /// <inheritdoc cref="Strings.IClassNames.Program"/>
        public SyntaxToken Program => Instances.SyntaxGenerator.Identifier(
            Instances.ClassNames_Strings.Program);
    }
}
