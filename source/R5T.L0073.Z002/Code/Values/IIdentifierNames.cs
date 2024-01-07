using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.L0073.Z002
{
    [ValuesMarker]
    public partial interface IIdentifierNames : IValuesMarker,
        Z001.IIdentifierNames
    {
        public IdentifierNameSyntax CreateBuilder => Instances.SyntaxGenerator.IdentifierName(
            Instances.Identifiers_Strings.CreateBuilder);

        public IdentifierNameSyntax WebApplication => Instances.SyntaxGenerator.IdentifierName(
            Instances.Identifiers_Strings.WebApplication);
    }
}
