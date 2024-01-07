using System;

using R5T.T0156;


namespace R5T.L0073.Y000
{
    public static partial class Documentation
    {
        [DocumentationMarker]
        public static partial class ForSyntaxNode
        {
            /// <summary>
            /// Horrifically, the various replace methods do <em>not</em> throw an exception if any of their inputs are not found.
            /// This means it is a silent error to try and replace syntax elements that are not present in the syntax node of interest.
            /// Given that the value-based semantics for all syntax elements makes it easy to inadvertently generate new syntax elements,
            /// when you attempt to replace syntax elements using the new syntax elements you will be left scratching your head as to why your desired changes
            /// are not reflected.
            /// The solution is to create and use replace methods that offer this safety guarantee of erroring if inputs are not found.
            /// </summary>
            public static readonly object ReplaceMethodsDoNotErrorIfNotFound;
        }
    }
}
