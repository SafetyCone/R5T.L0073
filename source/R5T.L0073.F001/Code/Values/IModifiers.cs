using System;

using Microsoft.CodeAnalysis;

using R5T.T0131;


namespace R5T.L0073.F001
{
    [ValuesMarker]
    public partial interface IModifiers : IValuesMarker
    {
        public SyntaxToken Abstract => Instances.SyntaxTokenGenerator.Abtract_Keyword();
        public SyntaxToken Async => Instances.SyntaxTokenGenerator.Async_Keyword();
        public SyntaxToken Const => Instances.SyntaxTokenGenerator.Const_Keyword();
        public SyntaxToken Extern => Instances.SyntaxTokenGenerator.Extern_Keyword();
        public SyntaxToken File => Instances.SyntaxTokenGenerator.File_Keyword();
        public SyntaxToken In => Instances.SyntaxTokenGenerator.In_Keyword();
        public SyntaxToken Internal => Instances.SyntaxTokenGenerator.Internal_Keyword();
        public SyntaxToken New => Instances.SyntaxTokenGenerator.New_Keyword();
        public SyntaxToken Out => Instances.SyntaxTokenGenerator.Out_Keyword();
        public SyntaxToken Override => Instances.SyntaxTokenGenerator.Override_Keyword();
        public SyntaxToken Params => Instances.SyntaxTokenGenerator.Params_Keyword();
        public SyntaxToken Partial => Instances.SyntaxTokenGenerator.Partial_Keyword();
        public SyntaxToken Private => Instances.SyntaxTokenGenerator.Private_Keyword();
        public SyntaxToken Protected => Instances.SyntaxTokenGenerator.Protected_Keyword();
        public SyntaxToken Public => Instances.SyntaxTokenGenerator.Public_Keyword();
        public SyntaxToken Readonly => Instances.SyntaxTokenGenerator.Readonly_Keyword();
        public SyntaxToken Ref => Instances.SyntaxTokenGenerator.Ref_Keyword();
        public SyntaxToken Required => Instances.SyntaxTokenGenerator.Required_Keyword();
        public SyntaxToken Sealed => Instances.SyntaxTokenGenerator.Sealed_Keyword();
        public SyntaxToken Static => Instances.SyntaxTokenGenerator.Static_Keyword();
        public SyntaxToken Unsafe => Instances.SyntaxTokenGenerator.Unsafe_Keyword();
        public SyntaxToken Virtual => Instances.SyntaxTokenGenerator.Virtual_Keyword();
        public SyntaxToken Volatile => Instances.SyntaxTokenGenerator.Volatile_Keyword();
    }
}
