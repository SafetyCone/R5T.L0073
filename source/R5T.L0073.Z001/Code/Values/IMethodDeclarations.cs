using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.L0073.Z001
{
    [ValuesMarker]
    public partial interface IMethodDeclarations : IValuesMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Signatures.IMethodDeclarations _Signatures => Signatures.MethodDeclarations.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public MethodDeclarationSyntax Main_Asynchronous_Empty => Instances.SyntaxGenerator.Build(
            _Signatures.Main_Asynchronous,
            Instances.MethodDeclarationOperations.Add_Body);

        public MethodDeclarationSyntax Main_Asynchronous => Instances.SyntaxGenerator.Build(
            this.Main_Asynchronous_Empty,
            Instances.MethodDeclarationOperations.Add_Statement(
                Instances.ExpressionStatements.Console_WriteLine_HelloWorld
            ));

        public MethodDeclarationSyntax Main_Empty => Instances.SyntaxGenerator.Build(
            _Signatures.Main,
            Instances.MethodDeclarationOperations.Add_Body);

        public MethodDeclarationSyntax Main => Instances.SyntaxGenerator.Build(
            this.Main_Empty,
            Instances.MethodDeclarationOperations.Add_Statement(
                Instances.ExpressionStatements.Console_WriteLine_HelloWorld
            )
        );

        public MethodDeclarationSyntax Main_WithArgs_Empty => Instances.SyntaxGenerator.Build(
            _Signatures.Main_WithArgs,
            Instances.MethodDeclarationOperations.Add_Body);

        public MethodDeclarationSyntax Main_WithArgs => Instances.SyntaxGenerator.Build(
            this.Main_WithArgs_Empty,
            Instances.MethodDeclarationOperations.Add_Statement(
                Instances.ExpressionStatements.Console_WriteLine_HelloWorld
            )
        );
    }
}
