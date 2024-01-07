using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.L0073.Z001.Empty
{
    /// <summary>
    /// Empty class declarations (without any methods, properties, or other members).
    /// </summary>
    [ValuesMarker]
    public partial interface IClassDeclarations : IValuesMarker
    {
        public ClassDeclarationSyntax Program => Instances.SyntaxGenerator.Class(
            Instances.ClassNames.Program);

        public ClassDeclarationSyntax Program_Private => Instances.SyntaxGenerator.Build(
            this.Program,
            Instances.MemberDeclarationOperations.In_ModifyModifiersContext<ClassDeclarationSyntax>(
                Instances.MemberDeclarationOperations._Raw.Add_PrivateModifier));
    }
}
