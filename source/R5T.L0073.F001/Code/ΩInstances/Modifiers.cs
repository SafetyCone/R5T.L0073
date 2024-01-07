using System;


namespace R5T.L0073.F001
{
    public class Modifiers : IModifiers
    {
        #region Infrastructure

        public static IModifiers Instance { get; } = new Modifiers();


        private Modifiers()
        {
        }

        #endregion
    }
}
