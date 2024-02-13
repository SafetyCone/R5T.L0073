using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.L0073.T001;
using R5T.T0137;


namespace R5T.L0073.T003
{
    [ContextImplementationMarker]
    public class ClassDeclarationContext : IContextImplementationMarker,
        IWithCompilationUnit,
        IWithNamespaceDeclaration,
        IWithClassDeclaration,
        //IWithModifiers,
        IWithMemberDeclarationType<ClassDeclarationSyntax>
    {
        public CompilationUnitSyntax CompilationUnit { get; set; }
        public NamespaceDeclarationSyntax NamespaceDeclaration { get; set; }
        public ClassDeclarationSyntax ClassDeclaration { get; set; }
        public ClassDeclarationSyntax MemberDeclaration {
            get => this.ClassDeclaration;
            set => this.ClassDeclaration = value;
        }


        //public SyntaxTokenList Modifiers
        //{
        //    get => this.ClassDeclaration.Modifiers;
        //    set => this.ClassDeclaration = this.ClassDeclaration.WithModifiers(value);
        //}
    }
}
