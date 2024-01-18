using System;


namespace R5T.L0073.F001
{
    public class Spacings : ISpacings
    {
        #region Infrastructure

        public static ISpacings Instance { get; } = new Spacings();


        private Spacings()
        {
        }

        #endregion
    }
}
