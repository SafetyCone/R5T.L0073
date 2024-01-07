using System;


namespace R5T.L0073.Z001.Strings
{
    public class TypeNames : ITypeNames
    {
        #region Infrastructure

        public static ITypeNames Instance { get; } = new TypeNames();


        private TypeNames()
        {
        }

        #endregion
    }
}
