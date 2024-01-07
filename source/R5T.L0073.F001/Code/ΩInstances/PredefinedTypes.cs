using System;


namespace R5T.L0073.F001
{
    public class PredefinedTypes : IPredefinedTypes
    {
        #region Infrastructure

        public static IPredefinedTypes Instance { get; } = new PredefinedTypes();


        private PredefinedTypes()
        {
        }

        #endregion
    }
}
