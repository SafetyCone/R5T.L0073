using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.L0073.F001
{
    [FunctionalityMarker]
    public partial interface IClassDeclarationOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Raw.IClassDeclarationOperator _Raw => Raw.ClassDeclarationOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// Beyond just adding the method declaration as a member of the class, this method:
        /// <list type="number">
        /// <item>
        /// Adds a blank line as the separaing spacing of the method if it is not the first member of the class,
        /// else adds a new line if it is the first member of the class.</item>
        /// </list>
        /// </summary>
        public ClassDeclarationSyntax Add_Method(
            ClassDeclarationSyntax classDeclaration,
            MethodDeclarationSyntax method)
        {
            // Indent the method.
            var modifiedMethod = Instances.SyntaxIndentationOperator.Indent_Block(method);

            var hasMembers = this.Has_Members(classDeclaration);

            modifiedMethod = hasMembers
                // If there are already members, add a leading separating blank line.
                ? Instances.SyntaxOperator.Prepend_BlankLine(modifiedMethod)
                // Else, if this is the first member, add a new line.
                : Instances.SyntaxOperator.Prepend_NewLine(modifiedMethod)
                ;

            var output = classDeclaration.AddMembers(modifiedMethod);
            return output;
        }

        public ClassDeclarationSyntax Add_PublicModifier(ClassDeclarationSyntax classDeclaration)
        {
            var output = Instances.MemberDeclarationOperator.Add_Modifier(
                classDeclaration,
                Instances.MemberModifiers.Public);

            return output;
        }

        public ClassDeclarationSyntax Add_StaticModifier(ClassDeclarationSyntax classDeclaration)
        {
            var output = Instances.MemberDeclarationOperator.Add_Modifier(
                classDeclaration,
                Instances.MemberModifiers.Static);

            return output;
        }

        public bool Has_Members(ClassDeclarationSyntax classDeclaration)
        {
            var output = Instances.TypeDeclarationOperator.Has_Members(classDeclaration);
            return output;
        }
    }
}
