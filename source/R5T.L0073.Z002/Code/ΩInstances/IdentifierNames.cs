using System;


namespace R5T.L0073.Z002
{
    public class IdentifierNames : IIdentifierNames
    {
        #region Infrastructure

        public static IIdentifierNames Instance { get; } = new IdentifierNames();


        private IdentifierNames()
        {
        }

        #endregion
    }
}
