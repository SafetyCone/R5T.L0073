using System;


namespace R5T.L0073.Z001
{
    public class Parameters : IParameters
    {
        #region Infrastructure

        public static IParameters Instance { get; } = new Parameters();


        private Parameters()
        {
        }

        #endregion
    }
}
