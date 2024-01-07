using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using R5T.T0132;


namespace R5T.L0073.F001
{
    public partial interface ISyntaxTokenGenerator : IFunctionalityMarker
    {
        public SyntaxToken Abtract_Keyword()
        {
            // No text value is needed, keyword is enough.
            var output = this.Keyword(SyntaxKind.AbstractKeyword);
            return output;
        }

        public SyntaxToken Async_Keyword()
        {
            // No text value is needed, keyword is enough.
            var output = this.Keyword(SyntaxKind.AsyncKeyword);
            return output;
        }

        public SyntaxToken Class_Keyword()
        {
            // No text value is needed, keyword is enough.
            var output = this.Keyword(SyntaxKind.ClassKeyword);
            return output;
        }

        public SyntaxToken Const_Keyword()
        {
            // No text value is needed, keyword is enough.
            var output = this.Keyword(SyntaxKind.ConstKeyword);
            return output;
        }

        public SyntaxToken Enum_Keyword()
        {
            // No text value is needed, keyword is enough.
            var output = this.Keyword(SyntaxKind.EnumKeyword);
            return output;
        }

        public SyntaxToken Extern_Keyword()
        {
            // No text value is needed, keyword is enough.
            var output = this.Keyword(SyntaxKind.ExternKeyword);
            return output;
        }

        public SyntaxToken File_Keyword()
        {
            // No text value is needed, keyword is enough.
            var output = this.Keyword(SyntaxKind.FileKeyword);
            return output;
        }

        public SyntaxToken In_Keyword()
        {
            // No text value is needed, keyword is enough.
            var output = this.Keyword(SyntaxKind.InKeyword);
            return output;
        }

        public SyntaxToken Internal_Keyword()
        {
            // No text value is needed, keyword is enough.
            var output = this.Keyword(SyntaxKind.InternalKeyword);
            return output;
        }

        public SyntaxToken New_Keyword()
        {
            // No text value is needed, keyword is enough.
            var output = this.Keyword(SyntaxKind.NewKeyword);
            return output;
        }

        public SyntaxToken Out_Keyword()
        {
            // No text value is needed, keyword is enough.
            var output = this.Keyword(SyntaxKind.OutKeyword);
            return output;
        }

        public SyntaxToken Override_Keyword()
        {
            // No text value is needed, keyword is enough.
            var output = this.Keyword(SyntaxKind.OverrideKeyword);
            return output;
        }

        public SyntaxToken Params_Keyword()
        {
            // No text value is needed, keyword is enough.
            var output = this.Keyword(SyntaxKind.ParamsKeyword);
            return output;
        }

        public SyntaxToken Partial_Keyword()
        {
            // No text value is needed, keyword is enough.
            var output = this.Keyword(SyntaxKind.PartialKeyword);
            return output;
        }

        public SyntaxToken Private_Keyword()
        {
            // No text value is needed, keyword is enough.
            var output = this.Keyword(SyntaxKind.PrivateKeyword);
            return output;
        }

        public SyntaxToken Protected_Keyword()
        {
            // No text value is needed, keyword is enough.
            var output = this.Keyword(SyntaxKind.ProtectedKeyword);
            return output;
        }

        public SyntaxToken Public_Keyword()
        {
            // No text value is needed, keyword is enough.
            var output = this.Keyword(SyntaxKind.PublicKeyword);
            return output;
        }

        public SyntaxToken Readonly_Keyword()
        {
            // No text value is needed, keyword is enough.
            var output = this.Keyword(SyntaxKind.ReadOnlyKeyword);
            return output;
        }

        public SyntaxToken Ref_Keyword()
        {
            // No text value is needed, keyword is enough.
            var output = this.Keyword(SyntaxKind.RefKeyword);
            return output;
        }

        public SyntaxToken Required_Keyword()
        {
            // No text value is needed, keyword is enough.
            var output = this.Keyword(SyntaxKind.RequiredKeyword);
            return output;
        }

        public SyntaxToken Sealed_Keyword()
        {
            // No text value is needed, keyword is enough.
            var output = this.Keyword(SyntaxKind.SealedKeyword);
            return output;
        }

        public SyntaxToken Static_Keyword()
        {
            // No text value is needed, keyword is enough.
            var output = this.Keyword(SyntaxKind.StaticKeyword);
            return output;
        }

        public SyntaxToken Unsafe_Keyword()
        {
            // No text value is needed, keyword is enough.
            var output = this.Keyword(SyntaxKind.UnsafeKeyword);
            return output;
        }

        public SyntaxToken Virtual_Keyword()
        {
            // No text value is needed, keyword is enough.
            var output = this.Keyword(SyntaxKind.VirtualKeyword);
            return output;
        }

        public SyntaxToken Volatile_Keyword()
        {
            // No text value is needed, keyword is enough.
            var output = this.Keyword(SyntaxKind.VolatileKeyword);
            return output;
        }
    }
}
