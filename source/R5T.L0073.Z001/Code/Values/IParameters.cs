using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.L0073.Z001
{
    [ValuesMarker]
    public partial interface IParameters : IValuesMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// <para><value>string[] args</value></para>
        /// </summary>
        public ParameterSyntax args => Instances.SyntaxGenerator.Parameter(
            Instances.Types.Array_OfStrings,
            Instances.Identifiers.args);
#pragma warning restore IDE1006 // Naming Styles
    }
}
