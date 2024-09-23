using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;
using R5T.T0143;


namespace R5T.L0073.Z001
{
    [ValuesMarker]
    public partial interface IClassDeclarations : IValuesMarker
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        Empty.IClassDeclarations _Empty => Empty.ClassDeclarations.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public ClassDeclarationSyntax Program => Instances.SyntaxGenerator.Build(
            _Empty.Program,
            Instances.ClassDeclarationOperations.Add_Method(
                Instances.MethodDeclarations.Main)
            );

        public ClassDeclarationSyntax Program_Asynchronous => Instances.SyntaxGenerator.Build(
            _Empty.Program,
            Instances.ClassDeclarationOperations.Add_Method(
                Instances.MethodDeclarations.Main_Asynchronous)
            );

        public ClassDeclarationSyntax Program_Private => Instances.SyntaxGenerator.Build(
            _Empty.Program_Private,
            Instances.ClassDeclarationOperations.Add_Method(
                Instances.MethodDeclarations.Main)
            );
    }
}
