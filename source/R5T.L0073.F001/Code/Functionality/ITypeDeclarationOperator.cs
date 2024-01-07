using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.L0073.F001
{
    [FunctionalityMarker]
    public partial interface ITypeDeclarationOperator : IFunctionalityMarker
    {
        public bool Has_Members(TypeDeclarationSyntax typeDeclaration)
        {
            var output = typeDeclaration.Members.Any();
            return output;
        }
    }
}
