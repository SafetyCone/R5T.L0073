using System;


namespace R5T.L0073.Z001
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
