using System;


namespace R5T.L0073.F001
{
    public class Exceptions : IExceptions
    {
        #region Infrastructure

        public static IExceptions Instance { get; } = new Exceptions();


        private Exceptions()
        {
        }

        #endregion
    }
}
