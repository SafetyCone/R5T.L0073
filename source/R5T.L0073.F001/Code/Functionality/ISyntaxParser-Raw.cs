using System;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.L0073.F001.Raw
{
    /// <summary>
    /// A syntax parser that directly parses strings into syntax elements.
    /// </summary>
    [FunctionalityMarker]
    public partial interface ISyntaxParser : IFunctionalityMarker
    {
        /// <summary>
        /// Parses the text of any kind of a class declaration.
        /// </summary>
        public ClassDeclarationSyntax Parse_Class(string text)
        {
            var output = this.Parse_MemberDeclaration(text) as ClassDeclarationSyntax;
            return output;
        }

        /// <summary>
        /// Parse text of a compilation unit (a whole code file).
        /// </summary> 
        public CompilationUnitSyntax Parse_CompilationUnit(string text)
        {
            var output = SyntaxFactory.ParseCompilationUnit(text);
            return output;
        }

        /// <summary>
        /// Parses the text of any kind of member declaration (class, interface, method, namespace).
        /// </summary>
        public MemberDeclarationSyntax Parse_MemberDeclaration(string text)
        {
            var output = SyntaxFactory.ParseMemberDeclaration(text);
            return output;
        }

        /// <summary>
        /// Parses the text of any kind of a method declaration.
        /// </summary>
        public MethodDeclarationSyntax Parse_MethodDeclaration(string text)
        {
            var output = this.Parse_MemberDeclaration(text) as MethodDeclarationSyntax;
            return output;
        }
    }
}
