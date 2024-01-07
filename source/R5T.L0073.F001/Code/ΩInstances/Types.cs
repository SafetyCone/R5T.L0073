using System;


namespace R5T.L0073.F001
{
    public class Types : ITypes
    {
        #region Infrastructure

        public static ITypes Instance { get; } = new Types();


        private Types()
        {
        }

        #endregion
    }
}
