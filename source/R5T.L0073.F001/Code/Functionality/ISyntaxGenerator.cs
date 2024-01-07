using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.L0073.F001
{
    /// <summary>
    /// Produces the canonical configurations of each syntax element type (nodes, tokens, trivias, and other, primarily list types)
    /// from default name methods for each syntax element type.
    /// </summary>
    /// <remarks>
    /// Works by calling the static methods of <see cref="SyntaxFactory"/> for each syntax element type,
    /// unless the result of those syntax factory static methods is not the canonical configuration for the syntax element type.
    /// (For example, the resulting MethodDeclarationSyntax has no body!)
    /// In that case, a call is made to the default name method for the syntax element type in <see cref="Raw.ISyntaxGenerator"/> (which then call the syntax factor
    /// static method), and the result is modified to match the canonical configuration.
    /// </remarks>
    [FunctionalityMarker]
    public partial interface ISyntaxGenerator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Raw.ISyntaxGenerator _Raw => Raw.SyntaxGenerator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public ArgumentListSyntax ArgumentList(IEnumerable<ArgumentSyntax> arguments)
        {
            var separatedSyntaxList = this.SeparatedSyntaxList(arguments);

            var output = SyntaxFactory.ArgumentList(separatedSyntaxList);
            return output;
        }

        public ArgumentListSyntax ArgumentList(params ArgumentSyntax[] arguments)
        {
            return this.ArgumentList(arguments.AsEnumerable());
        }

        public ArgumentSyntax Argument(ExpressionSyntax expression)
        {
            var output = SyntaxFactory.Argument(expression);
            return output;
        }

        public ArgumentSyntax Argument(string value)
        {
            var stringLiteral = this.StringLiteralExpression(value);

            var output = this.Argument(stringLiteral);
            return output;
        }

        
        public ClassDeclarationSyntax Class(string className)
        {
            var classNameIdentifier = this.Identifier(className);

            var output = this.Class(classNameIdentifier);
            return output;
        }

        /// <summary>
        /// Outputs the canonical class, which has:
        /// <list type="number">
        /// <item>A separating space before the class name.</item>
        /// <item><inheritdoc cref="Y000.Fragments.ForOpenAndCloseBraceOnOwnLines" path="/summary"/></item>
        /// </list>
        /// </summary>
        public ClassDeclarationSyntax Class(SyntaxToken classNameIdentifier)
        {
            var modifiedClassNameIdentifier = Instances.SyntaxTokenOperator.Prepend_Space(classNameIdentifier);

            var output = SyntaxFactory.ClassDeclaration(modifiedClassNameIdentifier);

            output = Instances.WithBraceTokensOperator.Set_LeadingTrivias_Initial(output);

            return output;
        }

        public CompilationUnitSyntax CompilationUnit()
        {
            var output = SyntaxFactory.CompilationUnit();
            return output;
        }

        public ExpressionStatementSyntax ExpressionStatement(ExpressionSyntax expression)
        {
            var output = SyntaxFactory.ExpressionStatement(expression);
            return output;
        }

        public SyntaxToken Identifier(string simpleName)
        {
            var output = Instances.SyntaxTokenGenerator.Identifier(simpleName);
            return output;
        }

        public IdentifierNameSyntax IdentifierName(string identifierName)
        {
            var output = SyntaxFactory.IdentifierName(identifierName);
            return output;
        }

        public IdentifierNameSyntax IdentifierName(SyntaxToken identifier)
        {
            var output = SyntaxFactory.IdentifierName(identifier);
            return output;
        }

        public InvocationExpressionSyntax InvocationExpression(
            ExpressionSyntax expression,
            ArgumentListSyntax argumentList)
        {
            var output = SyntaxFactory.InvocationExpression(
                expression,
                argumentList);

            return output;
        }

        public MethodDeclarationSyntax MethodDeclaration(
           TypeSyntax returnType,
           SyntaxToken simpleMethodNameIdentifier)
        {
            var methodDeclaration = _Raw.MethodDeclaration(
                returnType,
                simpleMethodNameIdentifier);

            var output = this.Build(
                methodDeclaration,
                Instances.MethodDeclarationOperations.Add_Body,
                Instances.MethodDeclarationOperations.Set_IdentifierSeparatingSpacing);

            return output;
        }

        public MethodDeclarationSyntax MethodDeclaration(
            TypeSyntax returnType,
            string simpleMethodName)
        {
            var simpleMethodNameIdentifier = this.Identifier(simpleMethodName);

            var output = this.MethodDeclaration(
                returnType,
                simpleMethodNameIdentifier);

            return output;
        }

        public NameSyntax Name(string name)
        {
            var output = this.IdentifierName(name);
            return output;
        }

        /// <summary>
        /// Returns the canonical namespace, which has:
        /// <list type="number">
        /// <item>A separating space before the namespace name.</item>
        /// <item><inheritdoc cref="Y000.Fragments.ForOpenAndCloseBraceOnOwnLines" path="/summary"/></item>
        /// </list>
        /// </summary>
        public NamespaceDeclarationSyntax Namespace(NameSyntax namespaceName)
        {
            var modifiedNamespaceName = Instances.SyntaxOperator.Prepend_Space(namespaceName);

            var output = SyntaxFactory.NamespaceDeclaration(modifiedNamespaceName);

            output = Instances.WithBraceTokensOperator.Set_LeadingTrivias_Initial(output);

            return output;
        }

        /// <inheritdoc cref="Namespace(NameSyntax)"/>
        public NamespaceDeclarationSyntax Namespace(string namespaceName)
        {
            var namespaceNameSyntax = this.NamespaceName(namespaceName);

            var output = this.Namespace(namespaceNameSyntax);
            return output;
        }

        public NameSyntax NamespaceName(string namespaceName)
        {
            Instances.StringOperator.Verify_IsNotNullOrEmpty(namespaceName);

            var tokens = Instances.NamespaceNameOperator.Get_Tokens(namespaceName);

            var tokensCount = tokens.Length;

            NameSyntax Get_Name(string[] tokens, int currentIndex)
            {
                var token = tokens[currentIndex];

                var tokenIdentifierName = this.IdentifierName(token);

                if (currentIndex == 0)
                {
                    return tokenIdentifierName;
                }
                else
                {
                    var left = Get_Name(tokens, currentIndex - 1);

                    var output = this.QualifiedName(
                        left,
                        tokenIdentifierName);

                    return output;
                }
            }

            if(tokensCount < 1)
            {
                throw new Exception("Namespace name had no tokens.");
            }

            if(tokensCount < 2)
            {
                var output = this.IdentifierName(namespaceName);
                return output;
            }
            else
            {
                var output = Get_Name(tokens, tokensCount - 1);
                return output;
            }
        }

        public ParameterSyntax Parameter(
            TypeSyntax parameterType,
            SyntaxToken parameterName)
        {
            var output = _Raw.Parameter(
                parameterType,
                parameterName);

            output = Instances.SyntaxTokenOperator.Set_SeparatingSpacing(
                output.Identifier,
                Instances.SyntaxTriviaLists.Space,
                output);

            return output;
        }

        public ParameterSyntax Parameter(
            TypeSyntax parameterType,
            string parameterName)
        {
            var parameterNameIdentifier = Instances.SyntaxGenerator.Identifier(parameterName);

            return this.Parameter(
                parameterType,
                parameterNameIdentifier);
        }

        public PredefinedTypeSyntax PredefinedType(SyntaxToken keyword)
        {
            var output = SyntaxFactory.PredefinedType(keyword);
            return output;
        }

        public QualifiedNameSyntax QualifiedName(
            NameSyntax left,
            SimpleNameSyntax right)
        {
            var output = SyntaxFactory.QualifiedName(
                left,
                right);

            return output;
        }

        public SeparatedSyntaxList<TNode> SeparatedSyntaxList<TNode>(
            IEnumerable<TNode> nodes)
            where TNode : SyntaxNode
        {
            var output = SyntaxFactory.SeparatedList(nodes);
            return output;
        }

        public SeparatedSyntaxList<TNode> SeparatedSyntaxList<TNode>(
            params TNode[] nodes)
            where TNode : SyntaxNode
        {
            return this.SeparatedSyntaxList(nodes.AsEnumerable());
        }

        public MemberAccessExpressionSyntax SimpleMemberAccessExpression(
            IdentifierNameSyntax parent,
            IdentifierNameSyntax child)
        {
            var output = SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                parent,
                child);

            return output;
        }

        public MemberAccessExpressionSyntax SimpleMemberAccessExpression(
            string parentName,
            string childName)
        {
            var parent = this.IdentifierName(parentName);
            var child = this.IdentifierName(childName);

            var output = this.SimpleMemberAccessExpression(
                parent,
                child);

            return output;
        }

        public NameSyntax SimpleName(string simpleName)
        {
            var output = this.IdentifierName(simpleName);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="StringLiteralExpression_WithEnquoting(string)"/> as the default.
        /// </summary>
        public LiteralExpressionSyntax StringLiteralExpression(string value)
        {
            var output = this.StringLiteralExpression_WithEnquoting(value);
            return output;
        }

        public LiteralExpressionSyntax StringLiteralExpression_WithoutEnquoting(string value)
        {
            var valueToken = this.StringLiteral(value);

            var output = this.StringLiteralExpressionSyntax(valueToken);
            return output;
        }

        public LiteralExpressionSyntax StringLiteralExpression_WithEnquoting(string value)
        {
            var enquotedValue = Instances.StringOperator.Enquote(value);

            var output = this.StringLiteralExpression_WithoutEnquoting(enquotedValue);
            return output;
        }

        public SyntaxToken StringLiteral(string text)
        {
            var output = SyntaxFactory.Token(
                Instances.SyntaxTriviaLists.Empty,
                SyntaxKind.StringLiteralToken,
                text,
                text,
                Instances.SyntaxTriviaLists.Empty);

            return output;
        }

        public LiteralExpressionSyntax StringLiteralExpressionSyntax(SyntaxToken value)
        {
            var output = SyntaxFactory.LiteralExpression(
                SyntaxKind.StringLiteralExpression,
                value);

            return output;
        }

        public SyntaxTokenList SyntaxTokenList()
        {
            var output = SyntaxFactory.TokenList();
            return output;
        }

        public SyntaxTokenList SyntaxTokenList(
            IEnumerable<SyntaxToken> tokens)
        {
            var output = SyntaxFactory.TokenList(tokens);
            return output;
        }

        public SyntaxTokenList SyntaxTokenList(
            params SyntaxToken[] tokens)
        {
            var output = SyntaxFactory.TokenList(tokens);
            return output;
        }

        public TypeSyntax Type(string simpleTypeName)
        {
            var output = SyntaxFactory.IdentifierName(simpleTypeName);
            return output;
        }

        public UsingDirectiveSyntax UsingDirective(NameSyntax namespaceName)
        {
            var raw = _Raw.UsingDirective(namespaceName);

            var output = raw.WithName(
                Instances.SyntaxNodeOperator.Prepend_Space(raw.Name));

            return output;
        }

        public VariableDeclarationSyntax VariableDeclaration(
            string variableName)
        {
            var output = _Raw.VariableDeclaration(variableName);

            var identifier = output.Variables.First().Identifier;

            var spacedIdentifier = Instances.SyntaxOperator.Prepend_Space(identifier);

            output = Instances.SyntaxNodeOperator.Replace_Token(
                output,
                identifier,
                spacedIdentifier);

            return output;
        }
    }
}
