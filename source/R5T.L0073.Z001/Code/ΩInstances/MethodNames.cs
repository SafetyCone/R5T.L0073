using System;


namespace R5T.L0073.Z001.Strings
{
    public class MethodNames : IMethodNames
    {
        #region Infrastructure

        public static IMethodNames Instance { get; } = new MethodNames();


        private MethodNames()
        {
        }

        #endregion
    }
}
