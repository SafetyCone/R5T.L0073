using System;
using System.Collections.Generic;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;
using R5T.T0143;


namespace R5T.L0073.F001
{
    [ValuesMarker]
    public partial interface IMethodDeclarationOperations : IValuesMarker
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public Raw.IMethodDeclarationOperations _Raw => Raw.MethodDeclarationOperations.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public MethodDeclarationSyntax Add_Body(MethodDeclarationSyntax methodDeclaration)
        {
            return Instances.SyntaxGenerator.Build(
                methodDeclaration,
                _Raw.Add_Body,
                this.Set_BodyBraceSeparatingTrivias);
        }

        public Func<MethodDeclarationSyntax, MethodDeclarationSyntax> Add_Parameters(IEnumerable<ParameterSyntax> parameters)
        {
            return methodDeclaration => Instances.MethodDeclarationOperator.Add_Parameters(
                methodDeclaration,
                parameters);
        }

        public Func<MethodDeclarationSyntax, MethodDeclarationSyntax> Add_Parameters(params ParameterSyntax[] parameters)
        {
            return methodDeclaration => Instances.MethodDeclarationOperator.Add_Parameters(
                methodDeclaration,
                parameters);
        }

        public Func<MethodDeclarationSyntax, MethodDeclarationSyntax> Add_Statement(StatementSyntax statement)
        {
            return methodDeclaration => Instances.MethodDeclarationOperator.Add_Statement(
                methodDeclaration,
                statement);
        }

        public MethodDeclarationSyntax Set_BodyBraceSeparatingTrivias(MethodDeclarationSyntax methodDeclaration)
        {
            var bodyBraceOpen = methodDeclaration.Body.OpenBraceToken;

            methodDeclaration = Instances.SyntaxTokenOperator.Set_SeparatingSpacing(
                bodyBraceOpen,
                Instances.SyntaxTriviaLists.NewLine,
                methodDeclaration);

            var bodyBraceClose = methodDeclaration.Body.CloseBraceToken;

            methodDeclaration = Instances.SyntaxTokenOperator.Set_SeparatingSpacing(
                bodyBraceClose,
                Instances.SyntaxTriviaLists.NewLine,
                methodDeclaration);

            return methodDeclaration;
        }

        public MethodDeclarationSyntax Set_IdentifierSeparatingSpacing(MethodDeclarationSyntax methodDeclaration)
        {
            var identifier = Instances.MethodDeclarationOperator.Get_Identifier(methodDeclaration);

            return Instances.SyntaxTokenOperator.Set_SeparatingSpacing(
                identifier,
                Instances.SyntaxTriviaLists.Space,
                methodDeclaration);
        }

        public MethodDeclarationSyntax Set_ReturnTypeSeparatingSpacing_Space(MethodDeclarationSyntax methodDeclaration)
        {
            var newReturnType = methodDeclaration.ReturnType;

            newReturnType = newReturnType.WithLeadingTrivia(Instances.SyntaxTrivias.Whitespace_Space);

            var newMethodDeclaration = methodDeclaration.WithReturnType(newReturnType);
            return newMethodDeclaration;
        }
    }
}
