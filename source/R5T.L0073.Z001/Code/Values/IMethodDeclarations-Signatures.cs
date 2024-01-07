using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.L0073.Z001.Signatures
{
    /// <summary>
    /// Only the signature of various method declarations.
    /// (Signatures do not have a body.)
    /// </summary>
    [ValuesMarker]
    public partial interface IMethodDeclarations : IValuesMarker
    {
        public MethodDeclarationSyntax Main_Asynchronous => Instances.SyntaxGenerator.Build(
            Instances.SyntaxConstructors.MethodDeclaration(
                Instances.Types.Task,
                Instances.Identifiers_Strings.Main),
            Instances.MemberDeclarationOperations.In_ModifyModifiersContext<MethodDeclarationSyntax>(
                Instances.ModifiersOperations.Add_Static,
                Instances.ModifiersOperations.Add_Async),
            Instances.MethodDeclarationOperations.Set_ReturnTypeSeparatingSpacing_Space
        );

        public MethodDeclarationSyntax Main_WithoutArgs => Instances.SyntaxGenerator.Build(
            Instances.SyntaxConstructors.MethodDeclaration_VoidReturn(
                Instances.Identifiers_Strings.Main
            ),
            Instances.MemberDeclarationOperations.In_ModifyModifiersContext<MethodDeclarationSyntax>(
                Instances.ModifiersOperations.Add_Static
            ),
            Instances.MethodDeclarationOperations.Set_ReturnTypeSeparatingSpacing_Space
        );

        public MethodDeclarationSyntax Main_WithArgs => Instances.SyntaxGenerator.Build(
            this.Main_WithoutArgs,
            Instances.MethodDeclarationOperations.Add_Parameters(
                Instances.Parameters.args
            )
        );

        /// <summary>
        /// Chooses <see cref="Main_WithoutArgs"/> as the default.
        /// </summary>
        public MethodDeclarationSyntax Main => this.Main_WithoutArgs;
    }
}
