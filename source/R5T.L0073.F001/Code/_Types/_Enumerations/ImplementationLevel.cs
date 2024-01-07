using System;


namespace R5T.L0073.F001
{
    /// <summary>
    /// Whether the implementation is part of an inheritance hierarchy (abstract, virtual, override).
    /// </summary>
    public enum ImplementationLevel
    {
        /// <summary>
        /// The implementation modifier is left unspecified.
        /// (Which means the implementation does not participate in inheritance games.)
        /// </summary>
        Unspecified = 0,

        Abstract = 100,

        Virtual = 200,

        Override = 1000,
    }
}
