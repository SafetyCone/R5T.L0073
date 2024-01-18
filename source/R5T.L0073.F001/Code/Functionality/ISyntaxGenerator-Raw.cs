using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.L0073.F001.Raw
{
    /// <summary>
    /// Generates raw syntax elements, raw in the sense that no post-generation operations are performed after calling <see cref="SyntaxFactory"/> methods.
    /// </summary>
    /// <remarks>
    /// For each syntax element type, there is a canonical initial configuration.
    /// </remarks>
    [FunctionalityMarker]
    public partial interface ISyntaxGenerator : IFunctionalityMarker
    {
        public ArrayTypeSyntax ArrayType(TypeSyntax elementType)
        {
            var output = SyntaxFactory.ArrayType(elementType,
                this.SyntaxList(
                    SyntaxFactory.ArrayRankSpecifier()));
            return output;
        }

        public BlockSyntax Block()
        {
            var output = SyntaxFactory.Block();
            return output;
        }

        /// <summary>
        /// Requires a simple class name (cannot be namespaced).
        /// </summary>
        public ClassDeclarationSyntax Class(string className)
        {
            var output = SyntaxFactory.ClassDeclaration(className);
            return output;
        }

        public ClassDeclarationSyntax Class(SyntaxToken classNameIdentifier)
        {
            var output = SyntaxFactory.ClassDeclaration(classNameIdentifier);
            return output;
        }

        public EqualsValueClauseSyntax EqualsValueClause(ExpressionSyntax expression)
        {
            var output = SyntaxFactory.EqualsValueClause(expression);
            return output;
        }

        public MethodDeclarationSyntax MethodDeclaration_VoidReturn(string simpleMethodName)
        {
            var returnType = Instances.Types.Void;

            var output = this.MethodDeclaration(
               returnType,
               simpleMethodName);

            return output;
        }

        public MethodDeclarationSyntax MethodDeclaration_VoidReturn(SyntaxToken simpleMethodNameIdentifier)
        {
            var returnType = Instances.Types.Void;

            var output = this.MethodDeclaration(
                returnType,
                simpleMethodNameIdentifier);

            return output;
        }

        public MethodDeclarationSyntax MethodDeclaration(
            TypeSyntax returnType,
            SyntaxToken simpleMethodNameIdentifier)
        {
            var output = SyntaxFactory.MethodDeclaration(
                returnType,
                simpleMethodNameIdentifier);

            return output;
        }

        public MethodDeclarationSyntax MethodDeclaration(
            TypeSyntax returnType,
            string simpleMethodName)
        {
            var output = SyntaxFactory.MethodDeclaration(
               returnType,
               simpleMethodName);

            return output;
        }        

        public NamespaceDeclarationSyntax Namespace(NameSyntax namespaceName)
        {
            var output = SyntaxFactory.NamespaceDeclaration(namespaceName);
            return output;
        }

        public NamespaceDeclarationSyntax Namespace(string namespaceName)
        {
            var namespaceNameSyntax = Instances.SyntaxGenerator.NamespaceName(namespaceName);

            var output = this.Namespace(namespaceNameSyntax);
            return output;
        }

        public ParameterSyntax Parameter(
            TypeSyntax parameterType,
            SyntaxToken parameterNameIdentifier)
        {
            var output = SyntaxFactory.Parameter(
                Instances.AttributeListLists.Empty,
                Instances.ModifierSets.Empty,
                parameterType,
                parameterNameIdentifier,
                null);

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

        public ParameterListSyntax ParameterList(IEnumerable<ParameterSyntax> parameters)
        {
            var separatedSyntaxList = this.SeparatedSyntaxList(parameters);

            var output = SyntaxFactory.ParameterList(separatedSyntaxList);
            return output;
        }

        public SeparatedSyntaxList<TNode> SeparatedSyntaxList<TNode>(IEnumerable<TNode> nodes)
            where TNode : SyntaxNode
        {
            var output = SyntaxFactory.SeparatedList(nodes);
            return output;
        }

        public SeparatedSyntaxList<TNode> SeparatedSyntaxList<TNode>(params TNode[] nodes)
            where TNode : SyntaxNode
        {
            return this.SeparatedSyntaxList(nodes.AsEnumerable());
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

        public UsingDirectiveSyntax UsingDirective(NameSyntax namespaceName)
        {
            var output = SyntaxFactory.UsingDirective(namespaceName);
            return output;
        }

        public VariableDeclarationSyntax VariableDeclaration(
            TypeSyntax type,
            VariableDeclaratorSyntax declarator)
        {
            var declarators = this.SeparatedSyntaxList(declarator);

            var output = SyntaxFactory.VariableDeclaration(
                type,
                declarators);

            return output;
        }

        public VariableDeclarationSyntax VariableDeclaration(
            TypeSyntax type,
            string variableName)
        {
            var declarator = this.VariableDeclarator(variableName);

            var output = this.VariableDeclaration(
                type,
                declarator);

            return output;
        }

        public VariableDeclarationSyntax VariableDeclaration(
            string variableName)
        {
            var output = this.VariableDeclaration(
                Instances.Types.var,
                variableName);

            return output;
        }

        public VariableDeclarationSyntax VariableDeclaration(
            string variableName,
            ExpressionSyntax expression)
        {
            var initializer = this.EqualsValueClause(expression);

            var declarator = this.VariableDeclarator(
                variableName,
                initializer);

            var output = this.VariableDeclaration(
                Instances.Types.var,
                declarator);

            return output;
        }

        public VariableDeclaratorSyntax VariableDeclarator(
            string variableName)
        {
            var output = SyntaxFactory.VariableDeclarator(variableName);
            return output;
        }

        public VariableDeclaratorSyntax VariableDeclarator(
            SyntaxToken variableName)
        {
            var output = SyntaxFactory.VariableDeclarator(variableName);
            return output;
        }

        public VariableDeclaratorSyntax VariableDeclarator(
            SyntaxToken variableName,
            EqualsValueClauseSyntax initializer)
        {
            var output = SyntaxFactory.VariableDeclarator(
                variableName,
                null,
                initializer);

            return output;
        }

        public VariableDeclaratorSyntax VariableDeclarator(
            string variableName,
            EqualsValueClauseSyntax initializer)
        {
            var variableNameToken = Instances.SyntaxGenerator.Identifier(variableName);

            var output = this.VariableDeclarator(
                variableNameToken,
                initializer);

            return output;
        }
    }
}
