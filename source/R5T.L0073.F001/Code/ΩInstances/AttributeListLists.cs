using System;


namespace R5T.L0073.F001
{
    public class AttributeListLists : IAttributeListLists
    {
        #region Infrastructure

        public static IAttributeListLists Instance { get; } = new AttributeListLists();


        private AttributeListLists()
        {
        }

        #endregion
    }
}
