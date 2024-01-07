using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.L0073.F001.Raw
{
    [ValuesMarker]
    public partial interface IMemberDeclarationOperations : IValuesMarker
    {
        public TMemberDeclarationSyntax Add_PrivateModifier<TMemberDeclarationSyntax>(TMemberDeclarationSyntax memberDeclaration)
            where TMemberDeclarationSyntax : MemberDeclarationSyntax
        {
            return Instances.MemberDeclarationOperator.Add_PrivateModifier(memberDeclaration);
        }

        public TMemberDeclarationSyntax Add_PublicModifier<TMemberDeclarationSyntax>(TMemberDeclarationSyntax memberDeclaration)
            where TMemberDeclarationSyntax : MemberDeclarationSyntax
        {
            return Instances.MemberDeclarationOperator.Add_PublicModifier(memberDeclaration);
        }

        public TMemberDeclarationSyntax Add_StaticModifier<TMemberDeclarationSyntax>(TMemberDeclarationSyntax memberDeclaration)
            where TMemberDeclarationSyntax : MemberDeclarationSyntax
        {
            return Instances.MemberDeclarationOperator.Add_StaticModifier(memberDeclaration);
        }
    }
}
