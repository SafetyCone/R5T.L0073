using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.L0073.F001
{
    [FunctionalityMarker]
    public partial interface IHasMembersOperator : IFunctionalityMarker
    {
        public bool Has_Members(IHasMembers hasMembers)
        {
            var output = hasMembers.Members.Any();
            return output;
        }

        public bool Has_Members(NamespaceDeclarationSyntax namespaceDeclarationSyntax)
        {
            var hasMembers = new NamespaceDeclarationSyntaxWrapper(namespaceDeclarationSyntax);

            var output = this.Has_Members(hasMembers);
            return output;
        }
    }
}
