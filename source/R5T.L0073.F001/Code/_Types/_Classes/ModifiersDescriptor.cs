using System;

using R5T.T0142;


namespace R5T.L0073.F001
{
    /// <summary>
    /// Models the modifiers set for a code member (type, method, etc.)
    /// </summary>
    /// <remarks>
    /// See: <inheritdoc cref="Y000.Links.ForMemberModifiers"/>.
    /// </remarks>
    [DataTypeMarker]
    public class ModifiersDescriptor
    {
        public MemberAccessibilityLevel Accessibility { get; set; }
        public ImplementationLevel Implementation { get; set; }
        public bool Is_Async { get; set; }
        public bool Is_Const { get; set; }
        public bool Is_Extern { get; set; }
        public bool Is_New { get; set; }
        public bool Is_Partial { get; set; }
        public bool Is_ReadOnly { get; set; }
        public bool Is_Required { get; set; }
        public bool Is_Sealed { get; set; }
        public bool Is_Static { get; set; }
        public bool Is_Unsafe { get; set; }
        public bool Is_Volatile { get; set; }
    }
}
