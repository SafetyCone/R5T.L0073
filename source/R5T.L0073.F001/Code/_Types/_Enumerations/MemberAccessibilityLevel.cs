using System;


namespace R5T.L0073.F001
{
    /// <summary>
    /// Accessibility levels for members (classes, interfaces, methods, etc.).
    /// </summary>
    /// <remarks>
    /// See: <inheritdoc cref="Y000.Links.ForAccessibilityModifiers" path="/descendant::value"/>, and <inheritdoc cref="Y000.Links.ForAccessModifiers"/>.
    /// Also see: <seealso cref="Microsoft.CodeAnalysis.Accessibility"/>
    /// </remarks>
    public enum MemberAccessibilityLevel
    {
        /// <summary>
        /// The accessibility modifier is left unspecified.
        /// </summary>
        /// <remarks>
        /// Different members types (class, struct, interface, method, etc.) have different default accessibility levels if their accessibility level is left unspecified.
        /// See: <inheritdoc cref="Y000.Links.ForDefaultMemberAccessibilities" path="/descendant::value"/>.
        /// </remarks>
        Unspecified = 0,

        /// <summary>
        /// Accessible only within the same code file.
        /// </summary>
        /// <remarks>
        /// Useful for source-generator written types.
        /// See: <inheritdoc cref="Y000.Links.ForFileAccessibilityModifier" path="/descendant::value"/>
        /// </remarks>
        File = 10,

        /// <summary>
        /// Accessible only within the same type.
        /// </summary>
        Private = 100,

        /// <summary>
        /// Accessible only by derived types that are within the same assembly.
        /// (Really should be "InternalProtect", but that is just a different ordering of the words in the ProtectedInternal value,
        /// so a decision was probably made to use different terminology.)
        /// </summary>
        PrivateProtected = 150,

        /// <summary>
        /// Accessible only within the same assembly, but by all code within the same assembly.
        /// </summary>
        Internal = 200,

        /// <summary>
        /// Accessible from within the same class, or a derived class.
        /// </summary>
        Protected = 500,

        /// <summary>
        /// Accessible from within the same assembly, or from within a derived class.
        /// </summary>
        ProtectedInternal = 550,

        /// <summary>
        /// Accessiblity is equal to the accessibility of the type itself.
        /// </summary>
        Public = 1000,
    }
}
