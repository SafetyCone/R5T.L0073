using System;

using Microsoft.CodeAnalysis;

using R5T.T0131;


namespace R5T.L0073.Z001
{
    [ValuesMarker]
    public partial interface IClassNames : IValuesMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Strings.IClassNames _Strings => Strings.ClassNames.Instance;
#pragma warning restore IDE1006 // Naming Styles


        /// <inheritdoc cref="Strings.IClassNames.Program"/>
        public SyntaxToken Program => Instances.SyntaxGenerator.Identifier(
            Instances.ClassNames_Strings.Program);
    }
}
