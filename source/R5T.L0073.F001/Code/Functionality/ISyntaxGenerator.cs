using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        /// <summary>
        /// Quality-of-life overload for <see cref="SingleLineDocumentationCommentTrivia(IEnumerable{XmlNodeSyntax})"/>
        /// </summary>
        public DocumentationCommentTriviaSyntax DocumentationComment(
            IEnumerable<XmlNodeSyntax> contents)
        {
            var output = this.SingleLineDocumentationCommentTrivia(contents);
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="SingleLineDocumentationCommentTrivia(XmlNodeSyntax[])"/>
        /// </summary>
        public DocumentationCommentTriviaSyntax DocumentationComment(
            params XmlNodeSyntax[] contents)
        {
            var output = this.SingleLineDocumentationCommentTrivia(contents);
            return output;
        }

        /// <summary>
        /// Creates the canonical documentation coment, with lines contained in an &lt;summary&gt; element.
        /// </summary>
        public DocumentationCommentTriviaSyntax DocumentationComment(
            IEnumerable<string> lines)
        {
            var output = this.DocumentationComment(
                this.Summary_XmlDocumentationElement(
                    lines
                )
            );

            return output;
        }

        /// <inheritdoc cref="DocumentationComment(IEnumerable{string})"/>
        public DocumentationCommentTriviaSyntax DocumentationComment(
            params string[] lines)
        {
            var output = this.DocumentationComment(
                lines.AsEnumerable());

            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Resolves the ambiguity between <see cref="DocumentationComment(string[])"/> and <see cref="DocumentationComment(XmlNodeSyntax[])"/> when input arguments are empty.
        /// </remarks>
        public DocumentationCommentTriviaSyntax DocumentationComment()
        {
            var output = this.DocumentationComment(
                Instances.ArrayOperator.Empty<XmlNodeSyntax>());

            return output;
        }

        /// <summary>
        /// <inheritdoc cref="L0066.IStrings.Triple_Slashes" path="/summary"/>
        /// </summary>
        public SyntaxTrivia DocumentationCommentExteriorTrivia()
        {
            var output = Instances.SyntaxTriviaOperator.New(
                SyntaxKind.DocumentationCommentExteriorTrivia,
                // The documentation comment exterior trivia does not supply its own text, as expected.
                Instances.Strings.Triple_Slashes);

            return output;
        }

        public EqualsValueClauseSyntax EqualsValueClause(ExpressionSyntax expression)
        {
            var output = _Raw.EqualsValueClause(expression);

            output = Instances.SyntaxTokenOperator.Set_LeadingTrivia(
                output.EqualsToken,
                Instances.Spacings.Space,
                output);

            output = Instances.SyntaxTokenOperator.Set_TrailingSeparatingSpacing(
                output.EqualsToken,
                Instances.Spacings.Space,
                output);

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

        public InvocationExpressionSyntax InvocationExpression(
            ExpressionSyntax expression)
        {
            var output = SyntaxFactory.InvocationExpression(expression);
            return output;
        }

        public LocalDeclarationStatementSyntax LocalDeclarationStatement(VariableDeclarationSyntax variableDeclaration)
        {
            var output = SyntaxFactory.LocalDeclarationStatement(variableDeclaration);
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

        /// <inheritdoc cref="SingleLineDocumentationCommentTrivia(XmlNodeSyntax[])"/>
        public DocumentationCommentTriviaSyntax SingleLineDocumentationCommentTrivia(
            IEnumerable<XmlNodeSyntax> contents)
        {
            var output = this.SingleLineDocumentationCommentTrivia(
                contents.ToArray());

            return output;
        }

        /// <remarks>
        /// Adds an initial XmlTextLiteral element for the XML documentation comment leading space (which includes the XML documentation comment exterior).
        /// If this is undesirable, see <see cref="Raw.ISyntaxGenerator.SingleLineDocumentationCommentTrivia(XmlNodeSyntax[])"/>.
        /// </remarks>
        public DocumentationCommentTriviaSyntax SingleLineDocumentationCommentTrivia(
            params XmlNodeSyntax[] contents)
        {
            var modifiedContents = contents
                .Prepend(Instances.SyntaxNodes.XmlDocumentationCommentLeadingSpace);

            var output = _Raw.SingleLineDocumentationCommentTrivia(modifiedContents);
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

        public XmlElementSyntax Summary_XmlDocumentationElement(
            IEnumerable<string> lines)
        {
            var documentationCommentLines = lines
                .Select(this.XmlDocumentationCommentNewLine)
                ;

            var output = this.XmlElement(
                Instances.XmlDocumentationCommentElementNames.Summary,
                documentationCommentLines);

            return output;
        }

        public XmlElementSyntax Summary_XmlDocumentationElement(
            params string[] lines)
        {
            var output = this.Summary_XmlDocumentationElement(
                lines.AsEnumerable());

            return output;
        }

        public SyntaxList<T> SyntaxList<T>()
            where T : SyntaxNode
        {
            var output = SyntaxFactory.List<T>();
            return output;
        }

        public SyntaxList<TNode> SyntaxList<TNode>(
            IEnumerable<TNode> values)
            where TNode : SyntaxNode
        {
            var output = SyntaxFactory.List(values);
            return output;
        }

        public SyntaxList<T> SyntaxList<T>(
            params T[] values)
            where T : SyntaxNode
        {
            var output = this.SyntaxList(values.AsEnumerable());
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

        public UsingDirectiveSyntax UsingDirective(string namespaceName)
        {
            var namespaceName_Syntax = this.NamespaceName(namespaceName);

            var output = this.UsingDirective(namespaceName_Syntax);
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

        public VariableDeclarationSyntax VariableDeclaration(
            string variableName,
            ExpressionSyntax expression)
        {
            var initializer = this.EqualsValueClause(expression);

            var declarator = _Raw.VariableDeclarator(
                variableName,
                initializer);

            var output = _Raw.VariableDeclaration(
                Instances.Types.var,
                declarator);

            output = Instances.SyntaxTokenOperator.Set_LeadingTrivia(
                output.Variables.First().Identifier,
                Instances.Spacings.Space,
                output);

            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="SingleLineDocumentationCommentTrivia(IEnumerable{XmlNodeSyntax})"/>
        /// </summary>
        public DocumentationCommentTriviaSyntax XmlDocumentationComment(
            IEnumerable<XmlNodeSyntax> contents)
        {
            var output = this.SingleLineDocumentationCommentTrivia(contents);
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="SingleLineDocumentationCommentTrivia(XmlNodeSyntax[])"/>
        /// </summary>
        public DocumentationCommentTriviaSyntax XmlDocumentationComment(
            params XmlNodeSyntax[] contents)
        {
            var output = this.SingleLineDocumentationCommentTrivia(contents);
            return output;
        }

        public XmlTextSyntax XmlDocumentationCommentLine(string text)
        {
            var output = this.XmlText(
                Instances.SyntaxTokens.XmlDocumentationCommentLeadingSpace,
                this.XmlTextLiteral(
                    text
                )
            );

            return output;
        }

        public XmlTextSyntax XmlDocumentationCommentNewLine(string text)
        {
            var output = this.XmlText(
                Instances.SyntaxTokens.XmlTextLiteralNewLine,
                Instances.SyntaxTokens.XmlDocumentationCommentLeadingSpace,
                this.XmlTextLiteral(
                    text
                )
            );

            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Appends a <see cref="ISyntaxNodes.XmlDocumentationCommentLineLeadingSpace"/> for the XML element end tag to the contents of the element.
        /// Use <see cref="Raw.ISyntaxGenerator.XmlElement(string, IEnumerable{XmlNodeSyntax})"/> if this is undesirable.
        /// </remarks>
        public XmlElementSyntax XmlElement(
            string elementName,
            IEnumerable<XmlNodeSyntax> contents)
        {
            var modifiedContents = contents.Append(
                Instances.SyntaxNodes.XmlDocumentationCommentLineLeadingSpace);

            var output = _Raw.XmlElement(
                elementName,
                modifiedContents);

            return output;
        }
        
        /// <inheritdoc cref="XmlElement(string, IEnumerable{XmlNodeSyntax})"/>
        public XmlElementSyntax XmlElement(
            string elementName,
            params XmlNodeSyntax[] contents)
        {
            var output = this.XmlElement(
                elementName,
                contents.AsEnumerable());

            return output;
        }

        public XmlElementEndTagSyntax XmlElementEndTag(string elementName)
        {
            var elementNameSyntax = this.XmlName(elementName);

            var output = this.XmlElementEndTag(elementNameSyntax);
            return output;
        }

        public XmlElementEndTagSyntax XmlElementEndTag(XmlNameSyntax elementName)
        {
            var output = SyntaxFactory.XmlElementEndTag(elementName);
            return output;
        }

        public XmlElementStartTagSyntax XmlElementStartTag(string elementName)
        {
            var elementNameSyntax = this.XmlName(elementName);

            var output = this.XmlElementStartTag(elementNameSyntax);
            return output;
        }

        public XmlElementStartTagSyntax XmlElementStartTag(XmlNameSyntax elementName)
        {
            var output = SyntaxFactory.XmlElementStartTag(elementName);
            return output;
        }

        public XmlNameSyntax XmlName(string elementName)
        {
            var output = SyntaxFactory.XmlName(elementName);
            return output;
        }

        /// <summary>
        /// Uses <inheritdoc cref="F10Y.L0000.IStrings.NewLine_Windows" path="/summary"/>. (<see cref="F10Y.L0000.IStrings.NewLine_Windows"/>)
        /// </summary>
        public SyntaxToken XmlTextLiteralNewLine()
        {
            var output = Instances.SyntaxTokenGenerator.From(
                SyntaxKind.XmlTextLiteralNewLineToken,
                // The XML text literal new line token needs to supply its own text.
                // Use the Windows new line.
                Instances.Strings.NewLine_Windows);

            return output;
        }

        public SyntaxToken XmlTextLiteral(string text)
        {
            var output = Instances.SyntaxTokenGenerator.From(
                SyntaxKind.XmlTextLiteralToken,
                text);

            return output;
        }

        public XmlTextSyntax XmlText()
        {
            var output = SyntaxFactory.XmlText();
            return output;
        }

        public XmlTextSyntax XmlText(params SyntaxToken[] tokens)
        {
            var output = SyntaxFactory.XmlText(tokens);
            return output;
        }
    }
}
