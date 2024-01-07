using System;

using Microsoft.CodeAnalysis;

using R5T.T0131;


namespace R5T.L0073.F001
{
    [ValuesMarker]
    public partial interface IMemberModifiers : IValuesMarker
    {
        public SyntaxToken Abstract => Instances.Modifiers.Abstract;
        public SyntaxToken Async => Instances.Modifiers.Async;
        public SyntaxToken Const => Instances.Modifiers.Const;
        public SyntaxToken Extern => Instances.Modifiers.Extern;
        public SyntaxToken File => Instances.Modifiers.File;
        public SyntaxToken Internal => Instances.Modifiers.Internal;
        public SyntaxToken New => Instances.Modifiers.New;
        public SyntaxToken Override => Instances.Modifiers.Override;
        public SyntaxToken Partial => Instances.Modifiers.Partial;
        public SyntaxToken Private => Instances.Modifiers.Private;
        public SyntaxToken Protected => Instances.Modifiers.Protected;
        public SyntaxToken Public => Instances.Modifiers.Public;
        public SyntaxToken Readonly => Instances.Modifiers.Readonly;
        public SyntaxToken Required => Instances.Modifiers.Required;
        public SyntaxToken Sealed => Instances.Modifiers.Sealed;
        public SyntaxToken Static => Instances.Modifiers.Static;
        public SyntaxToken Unsafe => Instances.Modifiers.Unsafe;
        public SyntaxToken Virtual => Instances.Modifiers.Virtual;
        public SyntaxToken Volatile => Instances.Modifiers.Volatile;
    }
}
