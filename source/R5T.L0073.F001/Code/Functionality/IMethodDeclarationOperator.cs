using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.L0073.F001
{
    [FunctionalityMarker]
    public partial interface IMethodDeclarationOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Raw.IMethodDeclarationOperator _Raw => Raw.MethodDeclarationOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public MethodDeclarationSyntax Add_Parameters(
            MethodDeclarationSyntax methodDeclaration,
            IEnumerable<ParameterSyntax> parameters)
        {
            var parametersList = Instances.SyntaxGenerator._Raw.ParameterList(
                parameters);

            var output = methodDeclaration.WithParameterList(parametersList);
            return output;
        }

        public MethodDeclarationSyntax Add_PublicModifier(MethodDeclarationSyntax classDeclaration)
        {
            var output = Instances.MemberDeclarationOperator.Add_Modifier(
                classDeclaration,
                Instances.MemberModifiers.Public);

            return output;
        }

        public MethodDeclarationSyntax Add_StaticModifier(MethodDeclarationSyntax classDeclaration)
        {
            var output = Instances.MemberDeclarationOperator.Add_Modifier(
                classDeclaration,
                Instances.MemberModifiers.Static);

            return output;
        }

        public MethodDeclarationSyntax Add_Statement(
            MethodDeclarationSyntax methodDeclaration,
            StatementSyntax statement)
        {
            var indentedStatement = Instances.SyntaxIndentationOperator.Indent_Block(statement);

            var indentedStatementOnOwnLine = Instances.SyntaxNodeOperator.Prepend_NewLine(indentedStatement);

            return _Raw.Add_Statement(
                methodDeclaration,
                indentedStatementOnOwnLine);
        }

        public SyntaxToken Get_Identifier(MethodDeclarationSyntax methodDeclaration)
        {
            return methodDeclaration.Identifier;
        }

        /// <summary>
        /// Some complexity here in that the simple name identifier might be the keyword token of a predefined type (ex: void),
        /// the identifier of a simple name (ex: Task), or the identifier of the right simple name of a qualified name,
        /// or it might even be an exception to ask, since array, nullable, tuple, and other types have no simple name!
        /// </summary>
        public SyntaxToken Get_ReturnTypeSimpleNameIdentifier(MethodDeclarationSyntax methodDeclaration)
        {
            var output = methodDeclaration.ReturnType switch
            {
                PredefinedTypeSyntax predefinedType => predefinedType.Keyword,
                _ => throw new Exception("Unknown type syntax.")
            };

            return output;
        }
    }
}
