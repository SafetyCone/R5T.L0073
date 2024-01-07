using System;


namespace R5T.L0073.F001
{
    public class ExceptionMessages : IExceptionMessages
    {
        #region Infrastructure

        public static IExceptionMessages Instance { get; } = new ExceptionMessages();


        private ExceptionMessages()
        {
        }

        #endregion
    }
}
