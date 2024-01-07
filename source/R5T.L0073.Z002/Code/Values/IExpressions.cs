using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.L0073.Z002
{
    [ValuesMarker]
    public partial interface IExpressions : IValuesMarker
    {
        public InvocationExpressionSyntax WebApplication_CreateBuilder_Args => Instances.SyntaxGenerator.InvocationExpression(
            Instances.SyntaxGenerator.SimpleMemberAccessExpression(
                Instances.IdentifierNames.WebApplication,
                Instances.IdentifierNames.CreateBuilder),
            Instances.SyntaxGenerator.ArgumentList(
                Instances.SyntaxGenerator.Argument(
                    Instances.Identifiers_Strings_Net.args
                )
            )
        );
    }
}
