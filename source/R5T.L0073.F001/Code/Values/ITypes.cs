using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0131;


namespace R5T.L0073.F001
{
    [ValuesMarker]
    public partial interface ITypes : IValuesMarker
    {
#pragma warning disable IDE1006 // Naming Styles

        public IdentifierNameSyntax var => Instances.IdentifierNames.var;

#pragma warning restore IDE1006 // Naming Styles


        public ArrayTypeSyntax Array_OfStrings => Instances.SyntaxGenerator._Raw.ArrayType(
            this.String);

        public PredefinedTypeSyntax String => Instances.PredefinedTypes.String;

        public IdentifierNameSyntax Task => Instances.IdentifierNames.Task;

        public PredefinedTypeSyntax Void => Instances.PredefinedTypes.Void;
    }
}
