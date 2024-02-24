using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;
using R5T.L0073.T001;
using R5T.T0137;
using R5T.T0142;


namespace R5T.L0073.T002
{
    [ContextImplementationMarker, DataTypeMarker]
    public class ClassDeclarationContext :
        IClassDeclarationContext
    {
        public CompilationUnitSyntax CompilationUnit { get; set; }

        public NamespaceDeclarationSyntax NamespaceDeclaration { get; set; }

        public ClassDeclarationSyntax ClassDeclaration { get; set; }

        ClassDeclarationSyntax IWithSyntaxNode<ClassDeclarationSyntax>.SyntaxNode
        {
            get => this.ClassDeclaration;
            set => this.ClassDeclaration = value;
        }
        ClassDeclarationSyntax IHasSyntaxNode<ClassDeclarationSyntax>.SyntaxNode => this.ClassDeclaration;
    }
}
