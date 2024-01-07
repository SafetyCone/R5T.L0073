using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.L0073.Z001
{
    [ValuesMarker]
    public partial interface IExpressionStatements : IValuesMarker
    {
        public ExpressionStatementSyntax Console_WriteLine_HelloWorld => Instances.SyntaxGenerator.ExpressionStatement(
            Instances.SyntaxGenerator.InvocationExpression(
                Instances.SyntaxGenerator.SimpleMemberAccessExpression(
                    Instances.IdentifierNames.Console,
                    Instances.IdentifierNames.WriteLine),
                Instances.SyntaxGenerator.ArgumentList(
                    Instances.SyntaxGenerator.Argument(
                        Instances.Strings_Content.HelloWorld
                    )
                )
            )
        );
    }
}
