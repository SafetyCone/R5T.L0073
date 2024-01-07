using System;


namespace R5T.L0073.Z002.Strings
{
    public class Identifiers : IIdentifiers
    {
        #region Infrastructure

        public static IIdentifiers Instance { get; } = new Identifiers();


        private Identifiers()
        {
        }

        #endregion
    }
}
