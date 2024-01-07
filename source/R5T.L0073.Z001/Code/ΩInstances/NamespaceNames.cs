using System;


namespace R5T.L0073.Z001
{
    public class NamespaceNames : INamespaceNames
    {
        #region Infrastructure

        public static INamespaceNames Instance { get; } = new NamespaceNames();


        private NamespaceNames()
        {
        }

        #endregion
    }
}
