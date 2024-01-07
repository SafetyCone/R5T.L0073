using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.L0073.F001
{
    [FunctionalityMarker]
    public partial interface INamespaceDeclarationOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Raw.INamespaceDeclarationOperator _Raw => Raw.NamespaceDeclarationOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public NamespaceDeclarationSyntax Add_Class(
            NamespaceDeclarationSyntax namespaceDeclaration,
            ClassDeclarationSyntax classDeclaration)
        {
            var modifiedClassDeclaration = Instances.SyntaxIndentationOperator.Indent_Block(classDeclaration);

            var hasMembers = this.Has_Members(namespaceDeclaration);

            modifiedClassDeclaration = hasMembers
                // If there are already members in the namespace, give the class two blank lines of leading separating spacing.
                ? Instances.SyntaxOperator.Prepend_TwoBlankLines(modifiedClassDeclaration)
                // Else, if this is the first member of the namespace, just prepend a new line.
                : Instances.SyntaxOperator.Prepend_NewLine(modifiedClassDeclaration)
                ;

            var output = _Raw.Add_Class(
                namespaceDeclaration,
                modifiedClassDeclaration);

            return output;
        }

        public bool Has_Members(NamespaceDeclarationSyntax namespaceDeclaration)
        {
            var output = Instances.HasMembersOperator.Has_Members(namespaceDeclaration);
            return output;
        }
    }
}
