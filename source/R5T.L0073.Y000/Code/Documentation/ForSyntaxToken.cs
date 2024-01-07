using System;

using R5T.T0156;


namespace R5T.L0073.Y000
{
    public static partial class Documentation
    {
        [DocumentationMarker]
        public static partial class ForSyntaxToken
        {
            /// <summary>
            /// The absolute next or previous token is the next or previous token when considering all special cases (zero-width, skipped, include directives, or documentation comments).
            /// </summary>
            public static readonly object AbsoluteNextOrPreviousToken;

            /// <summary>
            /// The simple next or previous token is the next or previous token without considering all special cases (zero-width, skipped, include directives, or documentation comments).
            /// </summary>
            public static readonly object SimpleNextOrPreviousToken;
        }
    }
}
